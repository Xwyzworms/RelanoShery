using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }


    private void Awake()
    {
        //Do shit

        this.stateMachine = new PlayerStateMachine();
        this.idleState = new PlayerIdleState(this, stateMachine, PlayerEnums.AnimState.Idle);
        this.moveState = new PlayerMoveState(this, stateMachine, PlayerEnums.AnimState.Move);


    }


    private void Start() 
    {
        
    }
}