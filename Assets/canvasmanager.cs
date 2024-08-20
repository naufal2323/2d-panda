using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasmanager : MonoBehaviour
{
    public static canvasmanager instance;
    public GameObject gameoverPanel; // Referensi ke GameOverPanel

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameoverPanel); // Hanya gameoverPanel yang menggunakan DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
