using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    GameObject player;

    public delegate void ChangeElement();
    public static event ChangeElement onNone;
    public static event ChangeElement onAir;
    public static event ChangeElement onEarth;
    public static event ChangeElement onFire;
    public static event ChangeElement onWater;

    public delegate void ChangeSanity();
    public static event ChangeSanity underQuarter;
    public static event ChangeSanity underHalf;
    public static event ChangeSanity underThreeFourths;
    public static event ChangeSanity fullSanity;

    Dictionary<BasePlayer.element, ChangeElement> elementEvent = new Dictionary<BasePlayer.element, ChangeElement>();

    private void Start()
    {
        elementEvent.Add(BasePlayer.element.None, onNone);
        elementEvent.Add(BasePlayer.element.Air, onAir);
        elementEvent.Add(BasePlayer.element.Earth, onEarth);
        elementEvent.Add(BasePlayer.element.Fire, onFire);
        elementEvent.Add(BasePlayer.element.Water, onWater);

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
    private void elementChange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BasePlayer.element currentElement = player.GetComponent<BasePlayer>().getCurrentElement();
            ChangeElement eventToCall = elementEvent[currentElement];


            if (eventToCall != null)
            {
                eventToCall();
            }
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
