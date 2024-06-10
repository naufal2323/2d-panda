using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxPowerCoin = 100;
    public int currentPowerCoin = 0;

    public PowerCoinBar powerCoinBar;

    // Start is called before the first frame update
    void Start()
    {
        currentPowerCoin = 0; // Set initial power coins to 0
        powerCoinBar.SetMaxPowerCoin(maxPowerCoin);
        powerCoinBar.SetPowerCoin(currentPowerCoin); // Update the UI to reflect the initial value
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "MyCoin")
        {
            Destroy(Coin.gameObject);
            AddPower(20); // Assume each MyCoin gives 20 power
        }
    }

    void AddPower(int power)
    {
        currentPowerCoin += power;

        // Ensure the currentPowerCoin does not exceed the maxPowerCoin
        if (currentPowerCoin > maxPowerCoin)
        {
            currentPowerCoin = maxPowerCoin;
        }

        powerCoinBar.SetPowerCoin(currentPowerCoin);
    }
}
