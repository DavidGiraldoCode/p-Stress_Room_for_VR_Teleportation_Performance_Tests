using UnityEngine;
public class GUIStartSession : MonoBehaviour, IGameStateMutator
{
    [SerializeField] private GameState _gameState;
    
    private void OnEnable() 
    {
        IGameStateMutator.CheckForGameState(_gameState, name);    
    }

    public void StartSession()
    {
        _gameState.SessionState = State.ONGOING;
    }

    public void StateChangedHandler(State previousState, State newState)
    {
        throw new System.NotImplementedException();
    }
}
