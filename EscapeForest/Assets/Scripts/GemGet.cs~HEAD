using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGet : MonoBehaviour
{

    [SerializeField] private Signal stepSignal;

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("activate", true);
            stepSignal.Raise();
        }
    }

}
