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
    public float coinSpawnChance = 10f;  // Kesempatan spawn koin

    [Header("Spawn Settings")]
    public float platformSpawnTimer = 2f;
    public float minX = -1.3f; // Memperluas area spawn ke kiri
    public float maxX = 1.3f;  // Memperluas area spawn ke kanan
    public float maxPlatformDistance = 1.3f; // Jarak maksimum antar platform

    private float currentPlatformSpawnTimer;
    private int platformSpawnCount;
    private Indicator playerIndicator;
    private Vector3 lastSpawnPosition; // Menyimpan posisi spawn terakhir

    // Object pooling
    private Queue<GameObject> platformPool = new Queue<GameObject>();
    private Queue<GameObject> coinPool = new Queue<GameObject>();
    public int initialPoolSize = 10;

    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
        playerIndicator = FindFirstObjectByType<Indicator>();

        // Inisialisasi object pools
        InitializePool(platformPrefab, platformPool, initialPoolSize);
        InitializePool(coinPrefab, coinPool, initialPoolSize);

        // Inisialisasi posisi spawn terakhir
        lastSpawnPosition = transform.position;
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

        // Hasilkan posisi x baru dan pastikan tidak terlalu jauh dari platform sebelumnya
        float newX;
        do
        {
            newX = Random.Range(minX, maxX);
        } while (Mathf.Abs(newX - lastSpawnPosition.x) > maxPlatformDistance);

        spawnPosition.x = newX;

        GameObject newPlatform = GetPlatformToSpawn(spawnPosition);
        if (newPlatform != null)
        {
            newPlatform.transform.parent = transform;
        }

        // Update posisi spawn terakhir
        lastSpawnPosition = spawnPosition;

        // Reset timer setelah spawn platform
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    GameObject GetPlatformToSpawn(Vector3 position)
    {
        GameObject platformToSpawn = null;

        switch (platformSpawnCount)
        {
            case 1:
                platformToSpawn = GetFromPool(platformPrefab, position);
                TrySpawnCoin(platformToSpawn);
                break;
            case 2:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? GetFromPool(platformPrefab, position)
                    : GetFromPool(movingPlatforms[Random.Range(0, movingPlatforms.Length)], position);
                TrySpawnCoin(platformToSpawn);
                break;
            case 3:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? GetFromPool(platformPrefab, position)
                    : GetFromPool(spikedPlatformPrefab, position);
                TrySpawnCoin(platformToSpawn);
                break;
            case 4:
                platformToSpawn = Random.Range(0, 2) > 0
                    ? GetFromPool(platformPrefab, position)
                    : GetFromPool(breakablePlatform, position);
                TrySpawnCoin(platformToSpawn);
                platformSpawnCount = 0;
                break;
        }

        return platformToSpawn;
    }

    void TrySpawnCoin(GameObject platform)
    {
        // Cek jika pemain memiliki koin kurang dari maksimum sebelum spawn koin
        if (playerIndicator != null && playerIndicator.currentPowerCoin < playerIndicator.maxPowerCoin && Random.value < coinSpawnChance)
        {
            Vector3 coinPosition = platform.transform.position;
            coinPosition.y += 0.5f; // Set posisi di atas platform

            // Tambahkan variasi pada posisi X koin dengan margin
            float platformWidth = platform.GetComponent<SpriteRenderer>().bounds.size.x;
            float margin = platformWidth * 0.1f; // Margin 10% di kedua sisi
            coinPosition.x += Random.Range(-platformWidth / 2 + margin, platformWidth / 2 - margin);

            GameObject newCoin = GetFromPool(coinPrefab, coinPosition);
            newCoin.transform.parent = transform;

            Debug.Log("Coin spawned at position: " + coinPosition);
        }
    }

    // Method untuk mengambil objek dari pool atau membuat yang baru jika pool kosong
    GameObject GetFromPool(GameObject prefab, Vector3 position)
    {
        Queue<GameObject> pool = prefab == coinPrefab ? coinPool : platformPool;

        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.transform.position = position;
            obj.SetActive(true);

            // Set gravity scale to 0 if it's a coin
            if (prefab == coinPrefab)
            {
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 0;
                }
            }

            return obj;
        }

        return Instantiate(prefab, position, Quaternion.identity);
    }

    // Method untuk menginisialisasi pool objek
    void InitializePool(GameObject prefab, Queue<GameObject> pool, int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    // Method untuk menonaktifkan objek dan memasukkannya kembali ke pool
    public void ReturnToPool(GameObject obj, GameObject prefab)
    {
        obj.SetActive(false);
        Queue<GameObject> pool = prefab == coinPrefab ? coinPool : platformPool;

        // Set gravity scale to 0 if it's a coin
        if (prefab == coinPrefab)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
            }
        }

        pool.Enqueue(obj);
    }
}
