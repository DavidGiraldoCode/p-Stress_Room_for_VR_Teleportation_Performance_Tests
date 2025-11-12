using UnityEngine;
using UnityEngine.UI;

public class GUISessionStateSubscriber : MonoBehaviour, IGameStateMutator
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        IGameStateMutator.CheckForGameState(_gameState, name);
        SubcribedToState();
        
    }

    void OnDisable()
    {
        UsubcribedToState();
    }

    private void SubcribedToState()
    {
        _gameState.OnSessionStateChanged += StateChangedHandler;
    }

    private void UsubcribedToState()
    {
        _gameState.OnSessionStateChanged -= StateChangedHandler;
    }

    void StateChangedHandler(State previousState, State newState)
    {
        Color feedbackColor = Color.white;
        switch(newState)
        {
            case State.STANDBY:
                feedbackColor = Color.yellow;
            break;
            case State.ONGOING:
                feedbackColor = Color.blue;
            break;
            case State.GAMEOVER:
                feedbackColor = Color.red;
            break;
            case State.TERMINATED:
                feedbackColor = Color.black;            
            break;
        }

        _image.color = feedbackColor;
    }

    void IGameStateMutator.StateChangedHandler(State previousState, State newState)
    {
        StateChangedHandler(previousState, newState);
    }
}
