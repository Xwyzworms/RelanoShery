using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine {
    // Start is called before the first frame update
    public PlayerState currentState { get; private set; }

    public void Initialize(PlayerState _startState) 
    {
        this.currentState = _startState;
        currentState.Enter();
    }

    public void UpdateState(PlayerState _updateState) 
    {
        currentState.Exit();
        this.currentState = _updateState;
        currentState.Enter();
    }


}
