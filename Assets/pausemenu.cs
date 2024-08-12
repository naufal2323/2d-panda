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
        // Jika menu jeda tidak aktif
        if (!PauseMenu.activeSelf)
        {
            // Membekukan waktu dalam permainan (Time.timeScale = 0) dan menampilkan menu jeda.
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }
        // Jika menu jeda aktif
        else
        {
            // Mengembalikan waktu permainan ke kecepatan normal (Time.timeScale = 1) dan menyembunyikan menu jeda.
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
        }
    }

    // Method untuk keluar dari permainan
    public void QuitToStartMenu()
    {
        // Mengembalikan waktu permainan ke kecepatan normal sebelum keluar ke Start Menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    // Method untuk melanjutkan permainan setelah dijeda
    public void Resume()
    {
        // Mengembalikan waktu permainan ke kecepatan normal (Time.timeScale = 1) dan menyembunyikan menu jeda.
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
}