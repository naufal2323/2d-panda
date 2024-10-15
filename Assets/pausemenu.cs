using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject PauseMenu; // Variabel publik untuk menyimpan objek menu jeda

    // Start is called before the first frame update
    void Start()
    {
        // Kode di sini dijalankan sekali pada awal saat objek dengan script ini diaktifkan.
        // Saat ini, tidak ada yang dilakukan pada method Start().
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Method untuk toggle pause state
    public void PauseToggle()
    {
        if (!PauseMenu.activeSelf)
        {
            // Membekukan waktu dalam permainan (Time.timeScale = 0) dan menampilkan menu jeda.
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }
        else
        {
            // Mengembalikan waktu permainan ke kecepatan normal (Time.timeScale = 1) dan menyembunyikan menu jeda.
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
        }
    }

    // Method untuk keluar ke Start Menu
    public void QuitToStartMenu()
    {
        Debug.Log("Returning to Start Menu");

        // Mengembalikan waktu permainan ke kecepatan normal sebelum keluar ke Start Menu
        Time.timeScale = 1f;

        // Periksa platform: di mobile, jangan keluar dari aplikasi
#if UNITY_ANDROID || UNITY_IOS
        SceneManager.LoadScene(0);
#else
            SceneManager.LoadScene("Start Menu");
#endif
    }

    // Method untuk melanjutkan permainan setelah dijeda
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
}