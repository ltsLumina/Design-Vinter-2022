using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;

    [Header("Jumping")]
    [SerializeField] float jumpForce;
    float gravityScaleAtStart = 1f;

    float fallingThreshold    = -1f;
    float fallingGravityScale = 2.5f;

    [Header("GroundCheck")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius;
    [SerializeField] bool isGrounded; // Serialized for debugging purposes.

    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        GroundCheck();
        Movement();
        Jump();

        // Debug.Log the velocity of the player.
        Debug.Log(myRigidbody.velocity);
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Movement()
    {
        float   xInput   = Input.GetAxis("Horizontal");
        //float   yInput   = Input.GetAxis("Vertical"); // Might use this later.
        //Vector2 dir = new Vector2(xInput, yInput);

        myRigidbody.velocity = new Vector2(xInput * moveSpeed, myRigidbody.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            if (/*myRigidbody.velocity.y <= fallingThreshold*/ !isGrounded)
            {
                myRigidbody.gravityScale = fallingGravityScale;
            }
            else if (isGrounded)
            {
                myRigidbody.gravityScale = gravityScaleAtStart;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}