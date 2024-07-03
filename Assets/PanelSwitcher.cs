using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;

    // Method untuk beralih ke panel settings
    public void ShowSettingsPanel()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    // Method untuk kembali ke panel utama
    public void ShowMainMenuPanel()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
}
