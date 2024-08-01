using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f; // Interval waktu untuk spawn koin
    public Transform[] spawnPoints;

    private Indicator playerIndicator;
    private float nextSpawnTime;

    void Start()
    {
        playerIndicator = FindObjectOfType<Indicator>();
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (playerIndicator != null && playerIndicator.currentPowerCoin < playerIndicator.maxPowerCoin)
            {
                SpawnCoin();
                nextSpawnTime = Time.time + spawnInterval;
            }
        }
    }

    void SpawnCoin()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(coinPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
