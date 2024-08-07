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
    public bool isGameOver;

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
        InitializeGame();
    }

    void InitializeGame()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        isGameOver = false;
        score = 0;
    }

    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        if (bestScoreText != null)
        {
            bestScoreText.text = "Best Score: " + bestScore.ToString();
        }
    }

    public void RestartGame()
    {
        InitializeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToHome()
    {
        InitializeGame();
        SceneManager.LoadScene("Start Menu");
    }
}
