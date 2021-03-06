﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Transform feet;
    public LayerMask groundLayer; // Should allways be "Ground". Select from inspector
    public float jumpTime; // So that player can jump higher the longer he presses SPACE
    [SerializeField] private float speed = 25f;
    [SerializeField] private float jump = 1.5f;
    private float jumpTimeCounter;
    private Rigidbody2D rigidBody;
    private Transform transform;
    private Animator animator;
    private float groundCheckRadius = 0.3f;
    private bool onGround;
    private bool isJumping;

    private KeyCode[] inputKeyCodes = new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
    private KeyCode[] arrowInputCode = new[] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow};

    public GameObject walkAudio;
    private AudioSource footsteps = null;

    private void Awake()
    {
        if (walkAudio != null)
        {
            footsteps = walkAudio.GetComponent<AudioSource>();
        }
        else {
            //Debug.Log("attach walkaudiosource");
        }

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        transform = gameObject.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        playerMovement();
    }

    private void playerMovement()
    {
        onGround = Physics2D.OverlapCircle(feet.position, groundCheckRadius, groundLayer);
        
        //Starts the jump
        if ((Input.GetKeyDown(inputKeyCodes[0])) && onGround)
        {
            isJumping = true;
            animator.SetBool("jumping", true);
            jumpTimeCounter = jumpTime;
            rigidBody.velocity = Vector2.up * jump;

            if (footsteps != null) {
                footsteps.Stop();

            }
        }

        //The longer you stay pressed the higher you go
        if ((Input.GetKey(inputKeyCodes[0])) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {

                rigidBody.velocity = Vector2.up * jump;
                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {
                isJumping = false;
                animator.SetBool("jumping", false);
            }
        }

        if (Input.GetKeyUp(inputKeyCodes[0])){
            isJumping = false;
            animator.SetBool("jumping", false);
        }

        if (Input.GetKey(inputKeyCodes[1]))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            //isJumping = false;
            animator.SetBool("walking", true);
            animator.SetBool("left", true);
            animator.SetBool("right", false);

            if (!footsteps.isPlaying && onGround && footsteps != null) {
                footsteps.Play();
            }
        }

        else if (Input.GetKey(inputKeyCodes[3]))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            animator.SetBool("walking", true);
            animator.SetBool("right", true);
            animator.SetBool("left", false);
            //isJumping = false;

            if (!footsteps.isPlaying && onGround && footsteps != null)
            {
                
                footsteps.Play();
            }

        }
        else
        {
            animator.SetBool("walking", false);
            footsteps.Stop();
        }

        if (!onGround && footsteps != null) {
            footsteps.Stop();
        }

    }

    public void resetInputKeyCodes(bool random)
    {
        if (!random)
        {
            inputKeyCodes = new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
            arrowInputCode = new[] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow};
        }
        else
        {
            int len = inputKeyCodes.Length;
            for(int i = 0; i < len - 1; i++) 
            {
                int rnd = Random.Range(i, len);
                KeyCode temp = inputKeyCodes[rnd];
                KeyCode arrowTmp = arrowInputCode[rnd];

                inputKeyCodes[rnd] = inputKeyCodes[i];
                inputKeyCodes[i] = temp;

                arrowInputCode[rnd] = arrowInputCode[i];
                arrowInputCode[i] = arrowTmp;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "FallThrough" && (Input.GetKey(inputKeyCodes[2])))
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
