using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private PlayerEnums.AnimState animation;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) 
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animation = _animation;
    }

    public virtual void Enter() 
    {
        
    }

    public virtual void Exit() 
    {
    
    }

    public virtual void Update() 
    {
    
    }
}
