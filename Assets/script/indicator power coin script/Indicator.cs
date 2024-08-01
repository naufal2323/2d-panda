using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public int maxPowerCoin = 5; // Maximum power coins needed for shield
    public int currentPowerCoin = 0;
    public bool hasShield = false; // Indicates if the player has a shield

    public PowerCoinBar powerCoinBar;

    // Start is called before the first frame update
    void Start()
    {
        currentPowerCoin = 0; // Set initial power coins to 0
        powerCoinBar.SetMaxPowerCoin(maxPowerCoin);
        powerCoinBar.SetPowerCoin(currentPowerCoin); // Update the UI to reflect the initial value
    }

    public void AddPower(int power)
    {
        currentPowerCoin += power;

        // Ensure the currentPowerCoin does not exceed the maxPowerCoin
        if (currentPowerCoin >= maxPowerCoin)
        {
            hasShield = true; // Player gains shield
            currentPowerCoin = maxPowerCoin; // Set coins to max (5)
        }

        powerCoinBar.SetPowerCoin(currentPowerCoin);
    }

    public void UseShield()
    {
        if (hasShield)
        {
            hasShield = false; // Use the shield
            currentPowerCoin = 0; // Reset power coins
            powerCoinBar.SetPowerCoin(currentPowerCoin); // Update the UI
        }
    }
}
