using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Sprite[] spriteMute; // 0 = on, 1 = off
    public Button buttonMute;
    public GameObject tutorialCanvas; // Tambahkan referensi ke Canvas tutorial

    private bool tutorialShown = false; // Flag untuk memastikan tutorial hanya ditampilkan sekali

    void Start()
    {
        UpdateMuteButton();
    }

    public void ButtonIngame()
    {
        if (!tutorialShown)
        {
            // Tampilkan tutorial terlebih dahulu
            ShowTutorial();
            tutorialShown = true; // Set flag agar tutorial hanya ditampilkan sekali
        }
        else
        {
            // Jika tutorial sudah ditampilkan, lanjutkan ke scene permainan
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
