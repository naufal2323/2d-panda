using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject soundManagerPrefab;

    private void Awake()
    {
        if (SoundManager.instance == null)
        {
            Instantiate(soundManagerPrefab);
        }
    }
}
