using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused,
}
public class GameStateManager : MonoBehaviour
{
    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }
    [Header("Debug(read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
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
                break;
            case GameState.None:
                Debug.Log("Your not supposed to be here");
                break;
            case GameState.Paused:
                Debug.Log("Gamestate set to Paused");
                break;
            case GameState.Gameplay:
                Debug.Log("Gamestate set to gameplay");
                break;
        }


        switch (previousState)
        {
            case GameState.Init:
                Debug.Log("init deactivated");
                break;
            case GameState.MainMenu:
                Debug.Log("MainMenu deactivated");
                break;
            case GameState.None:
                Debug.Log("none deactivated");
                break;
            case GameState.Paused:
                Debug.Log("Paused deactivated");
                break;
            case GameState.Gameplay:
                Debug.Log("gameplay deactivated");
                break;
        }
    }
    private void Update()
    {
        
    }
}
