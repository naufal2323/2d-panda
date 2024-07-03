using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Sprite[] spriteMute; // 0 = on 1 = off
    public Button buttonMute;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonIngame()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonMute()
    {
        SoundManager.instance.MuteSound();

        if (SoundManager.instance.music.mute == true)
        {

            buttonMute.image.sprite = spriteMute[1];
        }
        else
        {

            buttonMute.image.sprite = spriteMute[0];
        }
    }
}
