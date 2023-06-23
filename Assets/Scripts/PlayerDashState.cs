using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) : base(_player, _stateMachine, _animation)
    {

    }

    public override void Enter()
    {
        base.Enter();
        this.stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, 0);
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.dashSpeed * player.facingDirection, 0);
        if (this.stateTimer < 0) 
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}