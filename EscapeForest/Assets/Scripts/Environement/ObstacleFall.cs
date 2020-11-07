using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    Rigidbody2D r;
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }
    
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.name.Equals("Player"))
        {
            r.isKinematic = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.name.Equals("MaxHeight"))
        {
            // r.isKinematic = true;
        }
    }
}
