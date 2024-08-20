using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamesfx : MonoBehaviour
{
    public Sprite[] spriteMute; // 0 = on, 1 = off
    public Button buttonMute;

    // Start is called before the first frame update
    void Start()
    {
        buttonMute.onClick.AddListener(ButtonMute);
        UpdateMuteButton();
    }

    // Update sprite tombol mute SFX
    void UpdateMuteButton()
    {
        if (SoundManager.instance.soundFX.mute == true)
        {
            buttonMute.image.sprite = spriteMute[1];
        }
        else
        {
            buttonMute.image.sprite = spriteMute[0];
        }
    }

    // Method untuk toggle mute SFX
    public void ButtonMute()
    {
        SoundManager.instance.ToggleSFXMute();
        UpdateMuteButton();
    }
}
