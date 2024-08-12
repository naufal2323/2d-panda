using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasmanager : MonoBehaviour

{
    public static canvasmanager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
