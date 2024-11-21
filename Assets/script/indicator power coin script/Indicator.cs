using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public int maxPowerCoin = 5; // Maksimum power coin untuk mendapatkan shield
    public int currentPowerCoin = 0;
    public bool hasShield = false; // Menunjukkan apakah pemain memiliki shield

    public PowerCoinBar powerCoinBar;
    public GameObject bubbleShield; // Bubble sebagai indikator shield

    void Start()
    {
        currentPowerCoin = 0; // Set power coin awal ke 0
        powerCoinBar.SetMaxPowerCoin(maxPowerCoin); // Atur max power coin di UI
        powerCoinBar.SetPowerCoin(currentPowerCoin); // Update UI awal

        if (bubbleShield != null)
        {
            bubbleShield.SetActive(false); // Nonaktifkan bubble di awal
        }
    }


    public void AddPower(int power)
    {
        currentPowerCoin += power;

        // Pastikan currentPowerCoin tidak melebihi maxPowerCoin
        if (currentPowerCoin >= maxPowerCoin)
        {
            hasShield = true; // Player mendapatkan shield
            currentPowerCoin = maxPowerCoin; // Tetapkan ke nilai maksimum

            if (bubbleShield != null)
            {
                bubbleShield.SetActive(true); // Aktifkan bubble
            }
        }

        powerCoinBar.SetPowerCoin(currentPowerCoin); // Perbarui UI
    }

    public void UseShield()
    {
        if (hasShield)
        {
            hasShield = false; // Gunakan shield
            currentPowerCoin = 0; // Reset power coin

            if (bubbleShield != null)
            {
                bubbleShield.SetActive(false); // Nonaktifkan bubble
            }

            powerCoinBar.SetPowerCoin(currentPowerCoin); // Perbarui UI
        }
    }


    private void ActivateBubbleShield(bool status)
    {
        if (bubbleShield != null)
        {
            bubbleShield.SetActive(status);
        }
    }
}
