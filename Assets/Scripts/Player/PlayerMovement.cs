using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[Serializable]
public enum Colors
{
    white,
    red,
    blue,
    green,
}

[Serializable]
public enum ObjectInteract
{
    Button,
    Lever,
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float mSpeed = 5f;
    [SerializeField] private float jSpeed = 20f;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] float groundCheckY = 0.2f;
    [SerializeField] float groundCheckX = 0.5f;
    [SerializeField] LayerMask Ground;
    private string HorizontalAxis = "Horizontal";
    private bool doubleJump;
    [SerializeField] private float djSpeed = 10f;

    private float hMovement;

    [SerializeField] private ColorData colorData;

    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private Animator playerAnimator;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        
    }



    // Update is called once per frame
    void Update()
    {
        GetInput();

        Move();

        IsGrounded();

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            playerAnimator.SetBool("Jump", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                Debug.Log("Salto");

                _rb.AddForce(new Vector2(0, doubleJump ? djSpeed : jSpeed), ForceMode2D.Impulse);

                doubleJump = !doubleJump;

                playerAnimator.SetBool("DJump", true);
            }

            playerAnimator.SetBool("Jump", true);
            playerAnimator.SetBool("Grounded", false);

        }

        Flip();

        if (IsGrounded())
        {
            playerAnimator.SetBool("Grounded", true);
        }
    }


    private void Flip()
    {
        if(_rb.velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        if(_rb.velocity.x > 0)
        {
            playerSprite.flipX = false;
        }
    }

    public void GetInput()
    {
        hMovement = Input.GetAxis(HorizontalAxis);
    }

    public void Move()
    {
        _rb.velocity = new Vector2(mSpeed * hMovement, _rb.velocity.y);
        if(_rb.velocity.x != 0) 
        {
            playerAnimator.SetBool("isWalking", true);
        }else
        {
            playerAnimator.SetBool("isWalking", false);
        }
        
    }

    public bool IsGrounded()
    {
        if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, Ground)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, Ground)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, Ground))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}

   
