using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) : base(_player, _stateMachine, _animation)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
      
        if(xInput != 0 ) 
        {
            player.SetVelocity(xInput * .8f * player.moveSpeed, rb.velocity.y); ;
        }
        if (rb.velocity.y < 0) 
        {
            stateMachine.ChangeState(player.airState);
        }

    }
}