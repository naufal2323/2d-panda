using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Sprite[] spriteMute; // 0 = on, 1 = off
    public Button buttonMute;
    public GameObject tutorialCanvas; // Referensi ke Canvas tutorial

    void Start()
    {
        UpdateMuteButton();

        // Cek apakah tutorial sudah pernah ditampilkan
        if (!PlayerPrefs.HasKey("TutorialShown"))
        {
            PlayerPrefs.SetInt("TutorialShown", 0); // 0 = belum ditampilkan, 1 = sudah
            PlayerPrefs.Save();
        }
    }

    public void ButtonIngame()
    {
        // Jika tutorial belum pernah ditampilkan, tampilkan tutorial
        if (PlayerPrefs.GetInt("TutorialShown") == 0)
        {
            ShowTutorial();
            PlayerPrefs.SetInt("TutorialShown", 1); // Tandai bahwa tutorial sudah ditampilkan
            PlayerPrefs.Save();
        }
        else
        {
            // Jika tutorial sudah pernah ditampilkan, langsung mulai game
            StartGame();
        }
    }

    private void ShowTutorial()
    {
        tutorialCanvas.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialCanvas.SetActive(false);
        StartGame();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
        if (PanelSwitcher._instance != null)
        {
            PanelSwitcher._instance.NotifyEnterNewGame();
        }
    }

    public void ButtonMute()
    {
        SoundManager.instance.MuteMusic();
        UpdateMuteButton();
    }

    private void UpdateMuteButton()
    {
        if (SoundManager.instance.music.mute == true)
        {
            buttonMute.image.sprite = spriteMute[1];
        }
        else
        {
            buttonMute.image.sprite = spriteMute[0];
        }
        Debug.Log("UpdateMuteButton - Music Mute: " + SoundManager.instance.music.mute);
    }
}
