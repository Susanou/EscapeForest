using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    // James
    public void DoInteraction()
    {
        // Todo: Detect if it's a pickupable item or not. (pickup items vs. plant, torch, etc. )

        // if picupable, put it in the inventory & disable the object.

        // Todo: implement inventory 
        gameObject.SetActive(false);
    }
}
