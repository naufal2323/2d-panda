using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform Prefabs")]
    public GameObject platformPrefab;
    public GameObject spikedPlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;
    public GameObject coinPrefab;  // Prefab untuk koin
    public float coinSpawnChance = 0.10f;  // Kesempatan spawn koin

    [Header("Spawn Settings")]
    public float platformSpawnTimer = 2f;
    public float minX = -2f, maxX = 2f;

    private float currentPlatformSpawnTimer;
    private int platformSpawnCount;
    private Indicator playerIndicator;

    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
        playerIndicator = FindFirstObjectByType<Indicator>();
    }

    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        currentPlatformSpawnTimer -= Time.deltaTime;

        if (currentPlatformSpawnTimer > 0) return;

        platformSpawnCount++;
        Vector3 spawnPosition = transform.position;
        spawnPosition.x = Random.Range(minX, maxX);

        GameObject newPlatform = GetPlatformToSpawn(spawnPosition);
        if (newPlatform != null)
        {
            newPlatform.transform.parent = transform;
        }

        currentPlatformSpawnTimer = platformSpawnTimer; // Reset the timer after spawning a platform
    }

    GameObject GetPlatformToSpawn(Vector3 position)
    {
        GameObject platformToSpawn = null;

        switch (platformSpawnCount)
        {
            case 1:
                platformToSpawn = Instantiate(platformPrefab, position, Quaternion.identity);
                TrySpawnCoin(platformToSpawn);
                break;
            case 2:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? Instantiate(platformPrefab, position, Quaternion.identity)
                    : Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], position, Quaternion.identity);
                TrySpawnCoin(platformToSpawn);
                break;
            case 3:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? Instantiate(platformPrefab, position, Quaternion.identity)
                    : Instantiate(spikedPlatformPrefab, position, Quaternion.identity);
                TrySpawnCoin(platformToSpawn);
                break;
            case 4:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? Instantiate(platformPrefab, position, Quaternion.identity)
                    : Instantiate(breakablePlatform, position, Quaternion.identity);
                TrySpawnCoin(platformToSpawn);
                platformSpawnCount = 0;
                break;
        }

        return platformToSpawn;
    }

    void TrySpawnCoin(GameObject platform)
    {
        // Check if player has less than max coins before spawning a new coin
        if (playerIndicator != null && playerIndicator.currentPowerCoin < playerIndicator.maxPowerCoin && Random.value < coinSpawnChance)
        {
            Vector3 coinPosition = platform.transform.position;
            coinPosition.y += 0.5f; // Set position above platform

            // Add variation to the coin's X position with margin
            float platformWidth = platform.GetComponent<SpriteRenderer>().bounds.size.x;
            float margin = platformWidth * 0.1f; // 10% margin on both sides
            coinPosition.x += Random.Range(-platformWidth / 2 + margin, platformWidth / 2 - margin);

            GameObject newCoin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
            newCoin.transform.parent = transform;

            // Disable gravity on the coin's Rigidbody2D
            Rigidbody2D rb = newCoin.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
            }

            Debug.Log("Coin spawned at position: " + coinPosition);
        }
    }
}
