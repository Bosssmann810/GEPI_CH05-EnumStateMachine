using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField ] private GameObject SettingsUI;


    public void ShowMainMenu()
    {
        hideallUI();
        mainMenuUI.SetActive(true);

    }
    public void ShowGameplayUI()
    {
        hideallUI();
        gameplayUI.SetActive(true);
    }
    public void ShowPausedUI()
    {
        hideallUI();
        gameplayUI.SetActive(true);
        pausedUI.SetActive(true);
    }
    public void hideallUI()
    {
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        mainMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        SettingsUI.SetActive(false);
    }
    public void GameOVer()
    {
        hideallUI();
        gameplayUI.SetActive(true);
        gameOverUI.SetActive(true);

    }
    public void Settings()
    {
        hideallUI();
        SettingsUI.SetActive(true);
    }
}


