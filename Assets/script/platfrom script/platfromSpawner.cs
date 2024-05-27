using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikedPlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platformSpawnTimer = 2f;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;

    public float minX = -2f, maxX = 2f;

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

        if (currentPlatformSpawnTimer <= 0)
        {
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platformSpawnCount == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(
                        movingPlatforms[Random.Range(0, movingPlatforms.Length)],
                        temp, Quaternion.identity
                    );
                }
            }
            else if (platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikedPlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }

                platformSpawnCount = 0; // Reset the count
            }
            if(newPlatform)
                newPlatform.transform.parent = transform;
                currentPlatformSpawnTimer = platformSpawnTimer;
        }
    }
}
