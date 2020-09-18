using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Transform transform;

    [SerializeField] private float speed = 25f;
    [SerializeField] private float jump = 1.5f;

    [SerializeField] private bool onGround = true;
    private float groundCheckRadius = 0.3f; // Probably not needed. Radius would be caclculated from the center of the platform not the edges. 

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        //groundCheck();



        playerMovement();
       
    }


    //TODO Finish ground check
/*    private bool groundCheck()
    {
        List<Collider2D> colliders = new List<Collider2D>(Physics2D.OverlapCircleAll(transform.position,groundCheckRadius,));

        return colliders.;
    }*/



    private void playerMovement()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && onGround)
        {
            transform.position += jump * Vector3.up * speed * Time.deltaTime;
            onGround = false;
            Debug.Log(onGround);
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

    //Platoforms need 2 hitboxes, one for the actual platform, the other a little bit larger to detect if the player entered again.
    // (Also would allow for climbing possibly)
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Triggered");
        
        if (other.collider.tag == "Environement"){
            onGround = true;
        }
    }
}
