using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIColorTargetSelector : MonoBehaviour, IGameStateMutator
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private GameState _gameState;

    void OnEnable()
    {
        IGameStateMutator.CheckForGameState(_gameState, name);
        FillUpColorTargetOptions();
    }
    public void SafeAssignationOfGameState(GameState state)
    {
        _gameState = state;
    }

    private void FillUpColorTargetOptions()
    {
        
        _dropdown.ClearOptions();
        uint optionSize = (uint)_gameState.ColorTargets.Count;
        TMP_Dropdown.OptionData[] colorTargetOptions = new TMP_Dropdown.OptionData[optionSize];

        for (int i = 0; i < optionSize; i++)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
            optionData.text = _gameState.ColorTargets[i].ToString();
            colorTargetOptions[i] = optionData;
        }

        List<TMP_Dropdown.OptionData> colorTargetOptionsList = new List<TMP_Dropdown.OptionData>(colorTargetOptions);
        _dropdown.AddOptions(colorTargetOptionsList);
    }
    public void StateChangedHandler(State previousState, State newState)
    {
        throw new System.NotImplementedException();
    }
    
    public void SetNextColorTarget(Int32 i)
    {
        Debug.Log(i + " " + _dropdown.options[i].text);
        
    }
}
