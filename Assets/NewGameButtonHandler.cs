using UnityEngine;
using UnityEngine.UI;

public class NewGameButtonHandler : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button settingsButton;
    public Button quitButton;
    public Button backButton;
    public Button muteMusicButton;
    public Button muteSFXButton;

    private void Start()
    {
        // Pastikan SoundManager sudah ada sebelum mencoba menghubungkannya
        if (SoundManager.instance != null)
        {
            pauseButton.onClick.AddListener(SoundManager.instance.PauseGame);
            resumeButton.onClick.AddListener(SoundManager.instance.ResumeGame);
            settingsButton.onClick.AddListener(SoundManager.instance.OpenSettings);
            quitButton.onClick.AddListener(SoundManager.instance.QuitGame);
            backButton.onClick.AddListener(SoundManager.instance.Back);
            muteMusicButton.onClick.AddListener(SoundManager.instance.MuteMusic);
            muteSFXButton.onClick.AddListener(SoundManager.instance.MuteSFX);
        }
        else
        {
            Debug.LogError("SoundManager instance not found!");
        }
    }
}
