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
    public Button quithomegameover;
    public Button restart;

    private void Start()
    {
        // Pastikan SoundManager sudah ada sebelum mencoba menghubungkannya
        if (SoundManager.instance != null)
        {
            pauseButton.onClick.AddListener(SoundManager.instance.PauseGame);
            resumeButton.onClick.AddListener(SoundManager.instance.ResumeGame);
            settingsButton.onClick.AddListener(SoundManager.instance.OpenSettings);
            backButton.onClick.AddListener(SoundManager.instance.Back);
            muteMusicButton.onClick.AddListener(SoundManager.instance.MuteMusic);
            muteSFXButton.onClick.AddListener(SoundManager.instance.MuteSFX);
            restart.onClick.AddListener(SoundManager.instance.Restart);
        }
        else
        {
            Debug.LogError("SoundManager instance not found!");
        }
    }
}
