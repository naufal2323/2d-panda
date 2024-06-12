using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;


    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = ScoreNum.ToString();
    }

    private void OnTriggerEnter2D(Collider2D Platfrom)
    {
        if (Platfrom.tag == "Platfrom")
        {
            ScoreNum += 1;
            Destroy(Platfrom.gameObject);
            MyscoreText.text = ScoreNum.ToString();
        }
    }
}
