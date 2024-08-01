using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject Pause; // Variabel publik untuk menyimpan objek menu jeda

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PauseToggle()
    {
        // Jika menu jeda tidak aktif
        if (!Pause.activeSelf)
        {
            // Membekukan waktu dalam permainan (Time.timeScale = 0) dan menampilkan menu jeda.
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        // Jika menu jeda aktif
        else
        {
            // Mengembalikan waktu permainan ke kecepatan normal (Time.timeScale = 1) dan menyembunyikan menu jeda.
            Time.timeScale = 1f;
            Pause.SetActive(false);
        }
    }

    public void Resume()
    {
        // Mengembalikan waktu permainan ke kecepatan normal (Time.timeScale = 1) dan menyembunyikan menu jeda.
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }
}
