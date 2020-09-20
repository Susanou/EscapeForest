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

    private KeyCode[] inputKeyCodes = new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space };

private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        playerMovement();
       
    }

    private void playerMovement()
    {
        onGround = Physics2D.OverlapCircle(feet.position, groundCheckRadius, groundLayer);

        if ((Input.GetKeyDown(inputKeyCodes[0]) || Input.GetKeyDown(inputKeyCodes[4])) && onGround && !Input.GetKeyDown(inputKeyCodes[2]))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidBody.velocity = Vector2.up * jump;
        }

        if ((Input.GetKey(inputKeyCodes[0]) || Input.GetKey(inputKeyCodes[4])) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                
                rigidBody.velocity = Vector2.up * jump;
                jumpTimeCounter -= Time.deltaTime;
                
            }else{
                isJumping = false;
            }
        }

        if (Input.GetKey(inputKeyCodes[1]))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            isJumping = false;
        }
        if (Input.GetKey(inputKeyCodes[3]))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            isJumping = false;
        }
    }

    public void resetInputKeyCodes(bool random)
    {
        if (!random)
        {
            inputKeyCodes = new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space };
        }
        else
        {
            int len = inputKeyCodes.Length;
            for(int i = 0; i < len - 1; i++) 
            {
                int rnd = Random.Range(i, len);
                KeyCode temp = inputKeyCodes[rnd];
                inputKeyCodes[rnd] = inputKeyCodes[i];
                inputKeyCodes[i] = temp;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "FallThrough" && (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space)))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }
    }
    
    /*
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "FallThrough")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), false);
        }
    }
    */
}
