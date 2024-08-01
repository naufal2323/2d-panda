using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powertext : MonoBehaviour
{
    public Text MypowerText;
    private Indicator indicator;

    // Start is called before the first frame update
    void Start()
    {
        indicator = FindObjectOfType<Indicator>();
        UpdatePowerText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePowerText();
    }

    private void UpdatePowerText()
    {
        if (indicator != null)
        {
            MypowerText.text = indicator.currentPowerCoin + "/" + indicator.maxPowerCoin;
        }
    }
}
