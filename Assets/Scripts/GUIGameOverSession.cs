using UnityEngine;

public class GUIGameOverSession : MonoBehaviour, IGameStateMutator
{
    [SerializeField] private GameState _gameState;

    private void OnEnable()
    {
        IGameStateMutator.CheckForGameState(_gameState, name);
    }

    public void GameOverSession()
    {
        _gameState.SessionState = State.GAMEOVER;
    }

    public void StateChangedHandler(State previousState, State newState)
    {
        throw new System.NotImplementedException();
    }
}
