using System;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public static PanelSwitcher _instance;
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    internal void NotifyEnterNewGame()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
}
