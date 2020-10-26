using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollisions : MonoBehaviour
{

    private BoxCollider2D playerCollider;
    private BoxCollider2D pitCollider;

    // Start is called before the first frame update
    void Start()
    {
        
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        pitCollider = gameObject.GetComponent<BoxCollider2D>();

        //Let player fall into pit
        Physics2D.IgnoreCollision(playerCollider, pitCollider);


    }

}
