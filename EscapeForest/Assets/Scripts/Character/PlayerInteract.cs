﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentInterObj)
        {
            currentInterObj.SendMessage("DoInteraction");
            
        }
    }

    // Detects interactble objects by looking at a tag.

    // When the player gets in the range of the object's collider, 
    // this code will return(log) the name of the interactable object and sets the current object as a current interactable object.

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Interactable") || collision.CompareTag("Door"))
        {
            // Debug.Log(collision.name);
            currentInterObj = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Key")) {
            Destroy(collision.gameObject);
        }

    }

    // if the player gets out of the range of the object's collider, the current interactable object sets to null.

    void OnTriggerExit2D(Collider2D collision)
    {
    
            currentInterObj = null;
    }
}
