using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform Prefabs")]
    public GameObject platformPrefab;
    public GameObject spikedPlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

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
                break;
            case 2:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? Instantiate(platformPrefab, position, Quaternion.identity)
                    : Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], position, Quaternion.identity);
                break;
            case 3:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? Instantiate(platformPrefab, position, Quaternion.identity)
                    : Instantiate(spikedPlatformPrefab, position, Quaternion.identity);
                break;
            case 4:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? Instantiate(platformPrefab, position, Quaternion.identity)
                    : Instantiate(breakablePlatform, position, Quaternion.identity);
                platformSpawnCount = 0;
                break;
        }

        return platformToSpawn;
    }
}
