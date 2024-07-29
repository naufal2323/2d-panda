using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;

    public GameObject gameOverPanel;
    public Text scoreText;
    public Text bestScoreText;

    private int score = 0;
    private int bestScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        gameOverPanel.SetActive(false);  // Make sure the GameOverPanel is hidden at start
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    public void RestartGame()
    {
        // Reset the score
        score = 0;
        // Hide the game over panel
        gameOverPanel.SetActive(false);
        // Load the Gameplay scene again
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToHome()
    {
        // Reset the game state
        score = 0;
        gameOverPanel.SetActive(false);

        // Load the Start Menu scene
        SceneManager.LoadScene("Start Menu");
    }
}
