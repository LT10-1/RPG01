using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    
    private float moveSpeed = 5f;
    private float jumpForce;
    private int facingDir = 1;
    private bool facingRight = true;
    

    private float xInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Flip();
        }

        PlayerMove();
        CheckInput();
        AnimatorController();
        FlipController();
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce = 7.0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }

    private void PlayerMove()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

   

    private void AnimatorController()
    {

        bool IsMoving = rb.velocity.x != 0;
        anim.SetBool("IsMoving", IsMoving);

    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void FlipController()
    {
        if(rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

}
