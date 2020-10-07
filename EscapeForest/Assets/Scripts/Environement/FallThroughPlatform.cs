using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Use for when the player jumps into the bottom of a fall through platform
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            print("enter");
            Physics2D.IgnoreCollision(col, GetComponent<Collider2D>(), true);
        }
    }

    //Used to make fall through platforms solid again
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //print("exit");
            Physics2D.IgnoreCollision(col, GetComponent<Collider2D>(), false);
        }
    }
}
