using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platfromSpawner : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject spikedPlatfromprefab;
    public GameObject[] moving_Platfroms;
    public GameObject breakablePlatfrom;

    public float platfrom_Spawn_Timer = 2f;
    private float current_Platfrom_Spawn_Timer;

    private int platfrom_Spawn_Count;

    public float min_X = -2f, max_X = 2f;
    void Start() {
        current_Platfrom_Spawn_Timer = platfrom_Spawn_Timer;
        
    }


    void Update() {
        SpawnPlatfroms();
    }

    void SpawnPlatfroms () {
        current_Platfrom_Spawn_Timer -= Time.deltaTime;

        if(current_Platfrom_Spawn_Timer >= platfrom_Spawn_Timer) {

        }
    }
}
