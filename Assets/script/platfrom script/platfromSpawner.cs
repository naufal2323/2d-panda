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
    public float coinSpawnChance = 0.5f;  // Kesempatan spawn koin

    [Header("Spawn Settings")]
    public float platformSpawnTimer = 2f;
    public float minX = -2f, maxX = 2f;

    private float currentPlatformSpawnTimer;
    private int platformSpawnCount;

    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
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

        currentPlatformSpawnTimer = platformSpawnTimer;
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
        if (Random.value < coinSpawnChance)
        {
            Vector3 coinPosition = platform.transform.position;
            coinPosition.y += 0.5f; // Atur posisi di atas platform

            // Tambahkan variasi pada posisi X koin dengan margin
            float platformWidth = platform.GetComponent<SpriteRenderer>().bounds.size.x;
            float margin = platformWidth * 0.1f; // Margin 10% di kedua sisi
            coinPosition.x += Random.Range(-platformWidth / 2 + margin, platformWidth / 2 - margin);

            GameObject newCoin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
            newCoin.transform.parent = transform;

            // Nonaktifkan gravitasi pada Rigidbody2D koin
            Rigidbody2D rb = newCoin.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
            }

            Debug.Log("Coin spawned at position: " + coinPosition);
        }
    }
}
