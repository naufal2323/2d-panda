using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCoinScript : MonoBehaviour
{
    public int powerValue = 20;  // Nilai power untuk setiap koin

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Indicator playerIndicator = other.GetComponent<Indicator>();
            if (playerIndicator != null)
            {
                playerIndicator.AddPower(powerValue);
                Destroy(gameObject); // Hancurkan koin setelah diambil
            }
        }
    }
}
