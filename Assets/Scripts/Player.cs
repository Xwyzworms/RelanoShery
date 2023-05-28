using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Info")]
    public float moveSpeed = 12f;
    public float jumpForce = 12f;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }


    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }

    #endregion

    private void Awake()
    {
        //Do shit
        this.stateMachine = new PlayerStateMachine();
        this.idleState = new PlayerIdleState(this, stateMachine, PlayerEnums.AnimState.isIdle);
        this.moveState = new PlayerMoveState(this, stateMachine, PlayerEnums.AnimState.isMove);
        this.jumpState = new PlayerJumpState(this, stateMachine, PlayerEnums.AnimState.isAirState);
        this.airState = new PlayerAirState(this, stateMachine, PlayerEnums.AnimState.isAirState);
    }

    private void Start() 
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    private void Update() 
    {
        stateMachine.currentState.Update();
    
    }

    public void SetVelocity(float x_velocity, float y_velocity) 
    {
        rb.velocity = new Vector2(x_velocity, y_velocity);
    }
}