using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Transform transform;

    private float speed = 25f;

    private bool onGround = false;
    private float groundCheckRadius = 0.3f;

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))// && onGround)
        {
            transform.position += 1.5f * Vector3.up * speed * Time.deltaTime;
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
