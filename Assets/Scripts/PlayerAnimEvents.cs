using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class PlayerAnimEvents : MonoBehaviour 
{
    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        
    }

    public void AnimationTriggers() 
    {
        player.AttackOver();
        
    }

}