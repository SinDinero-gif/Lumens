using System;
using UnityEngine;


[Serializable]
public enum Colors
{
    white,
    red,
    blue,
    green,
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float mSpeed = 5f;
    [SerializeField] private float jSpeed = 20f;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] float groundCheckY = 0.2f;
    [SerializeField] float groundCheckX = 0.5f;
    [SerializeField] LayerMask Ground;
    private string HorizontalAxis = "Horizontal";
    private bool doubleJump;
    [SerializeField] private float djSpeed = 10f;

    private float hMovement;

    [SerializeField] private SpriteRenderer playerSprite;

    private Animator playerAnimator;

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
        
    void Update()
    {
        Flip();

        GetInput();

        Move();

        IsGrounded();


        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DJump", false);
            playerAnimator.SetBool("Grounded", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                _rb.AddForce(new Vector2(0, doubleJump ? djSpeed : jSpeed), ForceMode2D.Impulse);

                doubleJump = !doubleJump;
                jumpSoundEffect.Play();
                
            }
            jumpSoundEffect.Play();
            playerAnimator.SetBool("Jump", true);

            playerAnimator.SetBool("Grounded", false);

            if (!doubleJump)
            {
                playerAnimator.SetBool("DJump", true);
                playerAnimator.SetBool("Grounded", false);
            }

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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = other.transform;
            _rb.gravityScale = 10;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
            _rb.gravityScale = 2.8f;
        }
    }
}

   
