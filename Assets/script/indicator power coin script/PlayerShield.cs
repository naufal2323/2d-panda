using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private Indicator indicator;

    void Start()
    {
        indicator = GetComponent<Indicator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spiked Platform"))
        {
            if (indicator != null && indicator.hasShield)
            {
                indicator.UseShield(); // Use the shield and prevent player from dying
                Debug.Log("Shield used! Player is safe.");
            }
            else
            {
                // Implement player death or damage here
                Debug.Log("Player hit by spiked platform and no shield.");
            }
        }
    }
}
