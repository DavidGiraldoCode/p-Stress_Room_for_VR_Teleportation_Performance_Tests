using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The type of session the player is in, tryout does not count as data collection, real-game does
/// </summary>
public enum SessionType // Non-Flags Enum, Attribute	None, Intended Use	Single choice
{
    TRYOUT_GAME,
    REAL_GAME
}

/// <summary>
/// The state of the current gameplay session
/// </summary>
public enum State
{
    STANDBY,
    ONGOING,
    GAMEOVER,
    TERMINATED
}

public enum ColorTarget
{
    RED,
    BLUE,
    ORANGE,
    YELLOW,
    PURPLE,
    GREEN,
    NONE,
}

/// <summary>
/// Enables safe mutable capabilities to components
/// </summary>
public interface IGameStateMutator
{
    /// <summary>
    /// Checks if GameState Scriptable Object has been assinged in the editor
    /// </summary>
    /// <param name="_gameState"></param>
    static void CheckForGameState(GameState _gameState, string name)
    {
        if (_gameState == null)
            throw new ArgumentNullException("The GameState has not been assinged in the Editor to the " + name + " component");

    }
    void StateChangedHandler(State previousState, State newState);
}


/// <summary>
/// This component holds the configuration provided by the ExperimentManager through the GamePlayManager. 
/// It maintains the data model for the game, focusing solely on how it's configured at the beginning of a session. 
/// By default, it is set up for a tryout session.
/// </summary>

[CreateAssetMenu(fileName = "GameState", menuName = "Scriptable Objects/GameState")]
public class GameState : ScriptableObject
{
    [Tooltip("The type of session the player is in, tryout does not count as data collection, real-game does")]
    [SerializeField] private SessionType _sessionType = SessionType.TRYOUT_GAME;

    [Tooltip("The state of the current gameplay session")]
    [SerializeField] private State _state = State.STANDBY;

    [Tooltip("Type of teleportation method used.")]
    [SerializeField] private TeleportationType teleportationType = TeleportationType.STANDARD;

    // Add here all the new varibales to test difficulty
    [Header("Adaptive Difficulty Settings - Stressors")]
    [Tooltip("If true, the teleportation instructions will not match the color cue to the platform color.")]
    [SerializeField] private bool _biasedColorInstruction = false;
    [Tooltip("Reduction in allowed time for the player to reach the platform.")]
    [Range(1, 5)]
    [SerializeField] private float _reductionOnTimeoutToReachPlatform = 5f;

    [Tooltip("Reduction applied to the teleportation area radius after each timeout.")]
    [Range(0.05f, 1.0f)]
    [SerializeField] private float _reductionOnTeleportationAreaRadius = 0.25f;

    private ColorTarget _currentColor = ColorTarget.NONE;
    private ColorTarget _nextColor = ColorTarget.NONE;

    [SerializeField] private List<ColorTarget> _colorTargets = new List<ColorTarget>();

    #region Events
    public delegate void SessionStateChanged(State previousState, State newState);
    public event SessionStateChanged OnSessionStateChanged;
    public delegate void SessionTypeChanged(SessionType typeOfSession);
    public event SessionTypeChanged OnSessionTypeChanged;

    public delegate void TeleportationTypeChanged(TeleportationType newType);
    public event TeleportationTypeChanged OnTeleportationTypeChanged;

    public delegate void BiasedInstructionToggled(bool isActive);
    public event BiasedInstructionToggled OnBiasedInstructionToggled;

    public delegate void TimeoutReductionChanged(float newValue);
    public event TimeoutReductionChanged OnTimeoutReductionChanged;

    public delegate void AreaRadiusReductionChanged(float newValue);
    public event AreaRadiusReductionChanged OnAreaRadiusReductionChanged;

    public delegate void ColorTargetChanged(ColorTarget previous, ColorTarget next);
    public event ColorTargetChanged OnColorTargetChanged;
    #endregion

    #region Accessors
    public State SessionState
    {
        get { return _state; }
        set
        {
            if(_state == value) return;
            State previous  = _state;
            _state = value;
            OnSessionStateChanged?.Invoke(previous, value);
        }
    }

    public SessionType TypeOfSession
    {
        get { return _sessionType; }
        set
        {
            if(_sessionType == value) return;
            //SessionType previous = _sessionType;
            _sessionType = value;
            OnSessionTypeChanged?.Invoke(_sessionType);
        }
    }
    public TeleportationType TeleportationMethod
    {
        get => teleportationType;
        set
        {
            teleportationType = value;
            OnTeleportationTypeChanged?.Invoke(value);
        }
    }

    public bool BiasedColorInstruction
    {
        get => _biasedColorInstruction;
        set
        {
            if (_biasedColorInstruction == value) return;
            _biasedColorInstruction = value;
            OnBiasedInstructionToggled?.Invoke(value);
        }
    }

    public float ReductionOnTimeoutToReachPlatform
    {
        get => _reductionOnTimeoutToReachPlatform;
        set
        {
            if (Mathf.Approximately(_reductionOnTimeoutToReachPlatform, value)) return;
            _reductionOnTimeoutToReachPlatform = value;
            OnTimeoutReductionChanged?.Invoke(value);
        }
    }

    public float ReductionOnTeleportationAreaRadius
    {
        get => _reductionOnTeleportationAreaRadius;
        set
        {
            if (Mathf.Approximately(_reductionOnTeleportationAreaRadius, value)) return;
            _reductionOnTeleportationAreaRadius = value;
            OnAreaRadiusReductionChanged?.Invoke(value);
        }
    }

    public ColorTarget CurrentColor
    {
        get => _currentColor;
        set
        {
            if (_currentColor == value) return;
            var previous = _currentColor;
            _currentColor = value;
            OnColorTargetChanged?.Invoke(previous, value);
        }
    }

    public ColorTarget NextColor
    {
        get => _nextColor;
        set
        {
            if (_nextColor == value) return;
            var previous = _nextColor;
            _nextColor = value;
            OnColorTargetChanged?.Invoke(previous, value);
        }
    }
    
    public List<ColorTarget> ColorTargets => _colorTargets;
    
    #endregion
}
