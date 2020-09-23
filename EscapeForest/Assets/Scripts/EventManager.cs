using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    GameObject player;

    public delegate void ChangeElement(BasePlayer.element currentElement);
    public static event ChangeElement elementChanged;

    public delegate void ChangeSanity();
    public static event ChangeSanity randomMovement;
    public static event ChangeSanity underQuarter;
    public static event ChangeSanity underHalf;
    public static event ChangeSanity underThreeFourths;
    public static event ChangeSanity fullSanity;
    

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    //TODO: Sanity Event
 

    /**
     * Update checks for in game conditions that trigger an event
     * 
     */
    private void Update()
    {
        elementChange();
        
    }

    /**
     * Testing method to demonstrate how Event manager can send out event based on element of player
     * 
     */
    public  void elementChange()
    {
            if (elementChanged != null)
            {
                elementChanged(this.player.GetComponent<BasePlayer>().getCurrentElement());
            }
        
    }



    public static void underQuarterEventTrigger()
    {

            if(underQuarter != null)
            {
                underQuarter();
            }
        
    }

    public static void underHalfEventTrigger()
    {

        if (underHalf != null)
        {
            underHalf();
        }

    }

    public static void underThreeFourthsEventTrigger()
    {
        if (underThreeFourths != null)
        {
            underThreeFourths();
        }
    }

    public static void fullSanityEventTrigger()
    {
        if(fullSanity != null)
        {
            fullSanity();
        }
    }
}
