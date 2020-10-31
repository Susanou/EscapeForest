using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = false;
        StartCoroutine(FlickerAnimation());
    }

    IEnumerator FlickerAnimation()
    {
        float random = Random.Range(0, 0.7f);
        yield return new WaitForSeconds(random);
        animator.enabled = true;
    }
}
