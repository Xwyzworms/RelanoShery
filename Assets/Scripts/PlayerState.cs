using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private PlayerEnums.AnimState animation;
    protected Rigidbody2D rb;
    
    protected float xInput;
    protected float stateTimer;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, PlayerEnums.AnimState _animation) 
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animation = _animation;
        this.rb = _player.GetComponent<Rigidbody2D>();
    }

    public virtual void Enter() 
    {
        player.anim.SetBool(animation.ToString(), true);   
    }

    public virtual void Exit() 
    {
    
        player.anim.SetBool(animation.ToString(), false);
    }

    public virtual void Update() 
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("YVelocity", rb.velocity.y);

    }
}
