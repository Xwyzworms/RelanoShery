using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) : base(_player, _stateMachine, _animation)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            stateMachine.ChangeState(player.wallJumpState);

            return;
        }

        if (xInput != 0 && player.facingDirection != xInput)
        {
            stateMachine.ChangeState(player.idleState);
        }else if (yInput < 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else 
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.7f * rb.velocity.y);
        }

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }


    }
}