using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menusfx : MonoBehaviour
{
    public Sprite[] spriteMute; // 0 = on 1 = off
    public Button buttonMute;


    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonIngame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonMuteSFX()
    {
        SoundManager.instance.ToggleSFXMute();

        if (SoundManager.instance.soundFX.mute == true)
        {

            buttonMute.image.sprite = spriteMute[1];
        }
        else
        {

            buttonMute.image.sprite = spriteMute[0];
        }
    }
}
