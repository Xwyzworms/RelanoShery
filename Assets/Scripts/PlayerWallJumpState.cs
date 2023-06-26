using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) : base(_player, _stateMachine, _animation)
    {

    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(5f * -player.facingDirection, player.jumpForce);
        stateTimer = 0.2f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (stateTimer < 0 ) 
        {
            stateMachine.ChangeState(player.airState);
        }
        base.Update();


    }
}
