using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab coin
    public GameObject[] platformPrefabs; // Array prefab platform di mana coin akan muncul
    public float spawnInterval = 5f; // Interval waktu untuk spawn coin
    public Vector3 platformSpawnPosition = new Vector3(0, -3, 0); // Posisi spawn platform

    private void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        if (platformPrefabs.Length == 0)
            return;

        // Pilih prefab platform secara acak
        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject selectedPlatformPrefab = platformPrefabs[randomIndex];

        // Instansiasi platform pada posisi yang diinginkan
        GameObject platformInstance = Instantiate(selectedPlatformPrefab, platformSpawnPosition, Quaternion.identity);

        // Hitung posisi coin di atas platform
        Vector3 spawnPosition = platformInstance.transform.position;
        spawnPosition.y += 1f; // Sesuaikan nilai ini untuk menempatkan coin di atas platform

        // Spawn coin di posisi tersebut
        GameObject coinInstance = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        // Pastikan skala coin sesuai dengan yang diinginkan
        coinInstance.transform.localScale = new Vector3(1, 1, 1);
    }
}
