using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public Sprite[] spriteMute; // 0 = on 1 = off
    public Button buttonMute;

    // Start is called before the first frame update
    void Start()
    {
        buttonMute.onClick.AddListener(ButtonMute);
        UpdateMuteButton();
    }

    // Method untuk update sprite tombol mute
    void UpdateMuteButton()
    {
        if (SoundManager.instance.music.mute == true)
        {
            buttonMute.image.sprite = spriteMute[1];
        }
        else
        {
            buttonMute.image.sprite = spriteMute[0];
        }
    }

    // Method untuk toggle mute
    public void ButtonMute()
    {
        SoundManager.instance.MuteMusic();
        UpdateMuteButton();
    }
}