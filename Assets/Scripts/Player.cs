using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Info")]
    public float moveSpeed = 12f;
    public float jumpForce = 12f;

    [Header("Collision Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;

    [SerializeField] private LayerMask whatLayer;

    [SerializeField] public int facingDirection { get; private set; } = 1;

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

    private void Flip()
    {
        facingDirection *= -1;
        this.transform.Rotate(new Vector3(0, 180, 0));
    }

    public void FlipController(float x) 
    {
        if (x > 0 && facingDirection < 0)
        {
            Flip();
        }
        else if (x < 0 && facingDirection > 0) 
        {
            Flip();
        }
    }

    private void Update() 
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float x_velocity, float y_velocity) 
    {
        rb.velocity = new Vector2(x_velocity, y_velocity);
        FlipController(x_velocity);
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatLayer);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatLayer);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance)); // GroundCheck Gizmos
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));

    }
}