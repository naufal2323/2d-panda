using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
        [SerializeField]
    public AudioSource soundFX;
    public AudioSource music;

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LandSound ()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound ()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound ()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound ()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
    public void MuteSound()
    {
        if (music.mute == false)
        {
            music.mute = true;
        }
        else
        {
            music.mute = false;
        }
    }
    // Method untuk mute/unmute SFX
    public void ToggleSFXMute()
    {
        if (soundFX.mute == false)
        {
            soundFX.mute = true;
        }
        else
        {
            soundFX.mute = false;
        }
    }
}
