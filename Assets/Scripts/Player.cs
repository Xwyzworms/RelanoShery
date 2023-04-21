using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Dashing  Vars
     */
    [Header("Dashing vars")]
    [SerializeField] private float dashingDuration;
    [SerializeField] private float dashingSpeed;
    [SerializeField] private float dashingTimer;
    [SerializeField] private float dashingCooldown;
    [SerializeField] private float dashingTimerCooldown;
    private bool isDashing = false;
    /*
        Dashing  Vars
     */

    /*
        Attacking Vars
     */
    [Header("Attacking Vars")]
    [SerializeField] private bool isAttacking;
    [SerializeField] private int comboCounter = -1;
    [SerializeField] private float comboTimer;
    [SerializeField] private float comboDuration;
    /*
        Attacking Vars
     */

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
        DeltaTimeVars();
        AnimationController();
        InputHandler();
        MovementHandler();
        FlipController();
    }

    /*
        Handler for player Killing machine
     
     */
    /*
        Handler for player Killing machine
     
     */
    private void DeltaTimeVars() 
    {
        DashingHandlerTimer();
        AttackingHandlerTimer();
    }

    private void DashingHandlerTimer() 
    {
        dashingDuration -= Time.deltaTime;
        dashingCooldown -= Time.deltaTime;
        // TODO later
    }

    private void AttackingHandlerTimer() 
    {
        comboTimer -= Time.deltaTime;
        if (comboTimer < 0) 
        {

            comboCounter = 0;
            isAttacking = false;
        }
    }   
    private void DashingHandlerAbilityController() 
    {
        if (dashingCooldown < 0) 
        {
            dashingDuration = dashingTimer;
            dashingCooldown = dashingTimerCooldown;
        }
        
    }

    private void AttackingHandlerController() 
    {
        comboTimer =comboDuration;
        if (comboTimer > 0)
        {
            isAttacking = true;

            if (comboCounter > 2) {
                comboCounter = -1;
            }
            
            if (comboCounter <= 0)
            {
                comboCounter += 1;
            }
            else if (comboCounter == 1)
            {
                comboCounter += 1;
            }

            else if (comboCounter == 2)
            {
                comboCounter += 1;
            }

        }
        
    
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

        if (dashingDuration > 0 )
        {
            rb.velocity = new Vector2(xInput * dashingSpeed , 0);

        }
        else 
        {
            rb.velocity = new Vector2(xInput * moveSpeed , rb.velocity.y);
        }

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

        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            DashingHandlerAbilityController();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpController();
        }

        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            AttackingHandlerController();
        }
    }

    private void AnimationController() 
    {
        anim.SetBool("isDashing", dashingDuration > 0);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetFloat("xVelocity", xInput);
        anim.SetBool("isGround", isTouchingGround);

        /*
            Anim for attack
         */

        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }
}
