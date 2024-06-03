using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameManager intance;

    private void Awake()
    {
        if (intance == null)
            intance = this;
    }

    public void RestartGame ()
    {
        Invoke("RestartAfterTime", 2f);
    }

    void RestartAfterTime ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
 


} //clas
