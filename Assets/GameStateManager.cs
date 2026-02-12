using UnityEditor;
using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused,
    GameOver,
    Settings,
}
public class GameStateManager : MonoBehaviour
{
    public UIManager uimanager; 
    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }
    [Header("Debug(read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    

    private void Start()
    {
        uimanager = ServiceHub.Instance.uIManager;
        if(uimanager == null)
        {
            Debug.LogError("no ui manager");
        }
        SetState(GameState.Init);
        
    }

    public void SetState(GameState newState)
    {
        if(currentState == newState) return;
        previousState = currentState;
        currentState = newState;
        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();
        OnGameStateChanged(previousState, currentState);
    }
    public void Startgame()
    {
        SetState(GameState.Gameplay);
    }
    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        switch (newState) 
        {
            case GameState.Init:
                Debug.Log("Gamestate set to Init");
                SetState(GameState.MainMenu);
                break;
            case GameState.MainMenu:
                Debug.Log("Gamestate set to MainMenu");
                uimanager.ShowMainMenu();
                Time.timeScale = 1;
                break;
            case GameState.None:
                Debug.Log("Your not supposed to be here");
                
                break;
            case GameState.Paused:
                Debug.Log("Gamestate set to Paused");
                uimanager.ShowPausedUI();
                Time.timeScale = 0;
                break;
            case GameState.Gameplay:
                Debug.Log("Gamestate set to gameplay");
                uimanager.ShowGameplayUI();
                Time.timeScale = 1;
                break;
            case GameState.GameOver:
                uimanager.GameOVer();
                break;
            case GameState.Settings:
                uimanager.Settings();
                break;
        }
    }


    

    public void TogglePause()
    {
        Debug.Log("test");
        if(currentState == GameState.Paused) 
        {
            if (currentState == GameState.Gameplay) return;
            SetState(GameState.Gameplay);
        }
        else if (currentState == GameState.Gameplay)
        {
            if (currentState == GameState.Paused) return;
            SetState(GameState.Paused);
        }
    }
    public void GameOver()
    {
        if(currentState == GameState.Gameplay)
        {
            SetState(GameState.GameOver);
        }
    }
    public void BackToMenu()
    {
        SetState(GameState.MainMenu);
    }
    public void settings()
    {
        SetState(GameState.Settings);
    }
    public void back()
    {
        SetState(previousState);
    }
}
