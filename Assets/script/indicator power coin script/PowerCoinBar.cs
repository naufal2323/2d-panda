using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCoinBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPowerCoin(int powercoin)
    {
        slider.maxValue = powercoin;
        slider.value = powercoin;
    }

    public void SetPowerCoin(int powercoin)
    {
        slider.value = powercoin;
    }
}
