using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;


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
        pausedUI.SetActive(true);
    }
    public void hideallUI()
    {
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        mainMenuUI.SetActive(false);
    }
}
