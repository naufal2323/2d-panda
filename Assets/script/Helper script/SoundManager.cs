using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    public AudioSource soundFX;
    public AudioSource music;

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip, buttonClickClip, powerCoinClip; // Tambahkan buttonClickClip

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Jangan hancurkan objek saat scene berubah
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    // Method untuk memutar suara power coin
    public void PowerCoinSound()
    {
        soundFX.PlayOneShot(powerCoinClip);
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

    public void MuteSound()
    {
        music.mute = !music.mute;
    }

    // Method untuk mute/unmute SFX
    public void ToggleSFXMute()
    {
        soundFX.mute = !soundFX.mute;
    }

    // Method untuk memutar suara button click
    public void PlayButtonClickSound()
    {
        soundFX.PlayOneShot(buttonClickClip);
    }

    public void MuteMusic()
    {
        PlayButtonClickSound();
        music.mute = !music.mute;
        PlayerPrefs.SetInt("MusicMute", music.mute ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("MuteMusic - Music Mute: " + music.mute);
        Debug.Log("MuteMusic - PlayerPrefs: " + PlayerPrefs.GetInt("MusicMute"));
    }

    public void MuteSFX()
    {
        PlayButtonClickSound();
        soundFX.mute = !soundFX.mute;
        PlayerPrefs.SetInt("SFXMute", soundFX.mute ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("MuteSFX - SFX Mute: " + soundFX.mute);
        Debug.Log("MuteSFX - PlayerPrefs: " + PlayerPrefs.GetInt("SFXMute"));
    }



    // Method untuk pause game
    public void PauseGame()
    {
        PlayButtonClickSound();
        Time.timeScale = 0;
        Debug.Log("Game Paused");
    }

    // Method untuk resume game
    public void ResumeGame()
    {
        PlayButtonClickSound();
        Time.timeScale = 1;
        Debug.Log("Game Resumed");
    }

    // Method untuk quit game
    public void QuitGame()
    {
        PlayButtonClickSound();
        Debug.Log("Game Quit");
        Application.Quit();
    }

    // Method untuk membuka settings
    public void OpenSettings()
    {
        PlayButtonClickSound();
        Debug.Log("Settings Opened");
        // Logic untuk membuka settings
    }

    // Method untuk kembali ke menu sebelumnya
    public void Back()
    {
        PlayButtonClickSound();
        Debug.Log("Back to Previous Menu");
        // Logic untuk kembali ke menu sebelumnya
    }

    // Method untuk kembali ke start menu dri game over 
    public void QuitHomeGO()
    {
        PlayButtonClickSound();
        Debug.Log("Game Quit GO");
        Application.Quit();
    }

    // Method untuk memulai ulang game 
    public void Restart()
    {
        PlayButtonClickSound();
        Debug.Log("Restart game ");
        // Logic untuk kembali ke menu sebelumnya
    }
}
