using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Transform feet;
    public LayerMask groundLayer;
    public float jumpTime; // So that player can jump higher the longer he presses SPACE
    [SerializeField] private float speed = 25f;
    [SerializeField] private float jump = 1.5f;
    private float jumpTimeCounter;
    private Rigidbody2D rigidBody;
    private Transform transform;
    private float groundCheckRadius = 0.3f;
    private bool onGround;
    private bool isJumping;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        playerMovement();
       
    }

    private void playerMovement()
    {
        onGround = Physics2D.OverlapCircle(feet.position, groundCheckRadius, groundLayer);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && onGround)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidBody.velocity = Vector2.up * jump;
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                
                rigidBody.velocity = Vector2.up * jump;
                jumpTimeCounter -= Time.deltaTime;
                
            }else{
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //TODO implement crouching animation and collider adjustments
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
