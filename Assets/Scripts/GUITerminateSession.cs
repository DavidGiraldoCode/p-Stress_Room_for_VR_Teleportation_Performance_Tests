using UnityEngine;

public class GUITerminateSession : MonoBehaviour, IGameStateMutator
{
    [SerializeField] private GameState _gameState;

    private void OnEnable()
    {
        IGameStateMutator.CheckForGameState(_gameState, name);
    }

    public void TerminateSession()
    {
        _gameState.SessionState = State.TERMINATED;
    }

    public void StateChangedHandler(State previousState, State newState)
    {
        throw new System.NotImplementedException();
    }
}
