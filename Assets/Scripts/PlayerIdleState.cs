using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) : base(_player, _stateMachine, _animation)
    {

    }

    public override void Enter()
    {
        player.SetVelocity(0, 0);
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (xInput == player.facingDirection && player.IsWallDetected()) return;

        if (xInput != 0) 
        {
            stateMachine.ChangeState(player.moveState);
        }



    }
}