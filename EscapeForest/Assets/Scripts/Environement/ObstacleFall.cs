using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    private BasePlayer player;
    Rigidbody2D r;
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
         player = BasePlayer.instance;
    }
    
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.name.Equals("Player"))
        {
            r.isKinematic = false;
        }
    }
    
    /*
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.name.Equals("Player"))
        {
            player.addSanityOf(-20);
            player.transform.position = new Vector3(56, 5, 0);
            
        }
    }
    */
}
