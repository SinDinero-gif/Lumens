using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float mSpeed = 5f;
    private float jSpeed = 20f;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] float groundCheckY = 0.2f;
    [SerializeField] float groundCheckX = 0.5f;
    [SerializeField] LayerMask Ground;
    private string HorizontalAxis = "Horizontal";

    private float j2Speed = 10f;

    
    private float hMovement;

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

        Grounded();

        Jump();
    }

    public void GetInput()
    {
        hMovement = Input.GetAxis(HorizontalAxis);
    }

    public void Move()
    {
        _rb.velocity = new Vector2(mSpeed * hMovement, _rb.position.y);
    }

    public bool Grounded()
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

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            Debug.Log("salta");
            _rb.AddForce(new Vector2(_rb.position.y * jSpeed, (float)ForceMode2D.Impulse));
        }
    }

}
