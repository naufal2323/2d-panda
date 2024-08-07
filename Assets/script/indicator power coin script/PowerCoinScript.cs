using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCoinScript : MonoBehaviour
{
    public int powerValue = 1; // Nilai power untuk setiap koin

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Indicator playerIndicator = other.GetComponent<Indicator>();
            if (playerIndicator != null)
            {
                if (playerIndicator.currentPowerCoin < playerIndicator.maxPowerCoin)
                {
                    playerIndicator.AddPower(powerValue);
                    SoundManager.instance.PowerCoinSound(); // Memutar suara saat koin diambil
                    Destroy(gameObject); // Hancurkan koin setelah diambil
                }
            }
        }
    }
}
