using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;


    private float xInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private int playerDirection = 1;
    private bool isFacingRight = true;


    /*
        Ground check Vars
     */
    [Header("Collision vars")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] LayerMask groundMask;
    private bool isTouchingGround = true;
    /*
        Ground check Vars
    */


    /*
       Jump variabels
    */

    private bool isFalling = false;



    private void Awake() 
    {
        
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        AnimationController();
        InputHandler();
        MovementHandler();
        FlipController();

    }
   
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - groundCheckDistance, 0));
    }


    private void JumpController() 
    {
        if (isTouchingGround) 
        {
            JumpHandler();
        }
    }

    private void JumpHandler()
    {
        rb.velocity = new Vector2(this.transform.position.x, jumpForce); 
    }
    
    private void FlipController() 
    {
        if (rb.velocity.x > 0 && !isFacingRight)
        {
            FlipScaleHandler();
        }
        else if (rb.velocity.x < 0 && isFacingRight) 
        {
            FlipScaleHandler();
        }
    }
    private void MovementHandler()
    {
        rb.velocity = new Vector2(xInput * moveSpeed , rb.velocity.y);
        isTouchingGround = Physics2D.Raycast(this.transform.position, Vector2.down, groundCheckDistance, groundMask);
        if (rb.velocity.y < 0 && !isTouchingGround) 
        {
            isFalling = true;
        }
    }
    private void FlipScaleHandler() 
    {
        playerDirection = playerDirection * -1;
        isFacingRight = !isFacingRight;
        this.transform.localScale = new Vector2(playerDirection, this.transform.localScale.y);
    }

    private void FlipRotateHandler() 
    {
        playerDirection = playerDirection * -1;
        isFacingRight = !isFacingRight;
        this.transform.Rotate(new Vector3(0, 180, 0));
    }
    private void InputHandler()
    {
        xInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetKey(KeyCode.Space))
        {
            JumpController();
        }
    }

    private void AnimationController() 
    {
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetFloat("xVelocity", xInput);
        anim.SetBool("isGround", isTouchingGround);
    }
}
