using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) : base(_player, _stateMachine, _animation)
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
        if (rb.velocity.y == 0) 
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
} 