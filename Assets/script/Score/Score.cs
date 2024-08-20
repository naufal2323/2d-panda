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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with a platform
        if (collision.gameObject.CompareTag("Score Platform"))
        {
            ScoreNum += 1;
            MyscoreText.text = ScoreNum.ToString();
            GameManager2.instance.AddScore(1); // Update the global score in GameManager2
        }
    }
}
