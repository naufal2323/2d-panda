using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Sprite[] spriteMute; // 0 = on 1 = off
    public Button buttonMute;

    void Start()
    {
        UpdateMuteButton();
    }

    public void ButtonIngame()
    {
        SceneManager.LoadScene(1);
        if(PanelSwitcher._instance != null)
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