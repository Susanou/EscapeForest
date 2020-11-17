using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGet : MonoBehaviour
{

    [SerializeField] private Signal stepSignal;
    [SerializeField] private AudioSource gemNoise;

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
            StartCoroutine(GemDisappear());
        }
    }

    public IEnumerator GemDisappear()
    {
        gemNoise.Play();
        yield return new WaitForSeconds(2);
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
