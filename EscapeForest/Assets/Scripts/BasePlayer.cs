using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    /**
     * Class for BasePlayer behavior and interactions wtih Sanity and elements
     * 
     * @author 
     * 
     */

   
    private int maxSanity = 100;
    public enum element { None,Air,Earth,Fire,Water};
    private element currentElement = element.None;

    private int currentSanity = 100;
    public SanityBar sanityBar;


    public element getCurrentElement()
    {
        return currentElement;
    }

    public int getSanity()
    {
        return currentSanity;
    }

    public void increaseSanity(int amount)
    {
        if ((currentSanity += amount) > maxSanity)
        {
            currentSanity = 100;
        }
        else
        {
            currentSanity += amount;
        }
        sanityBar.setSanity(currentSanity);
    }

    public void decreaseSanity(int amount)
    {
        if (currentSanity -amount < 0)
        {
            currentSanity = 0;
        }
        else
        {
            currentSanity -= amount;
        }
        sanityBar.setSanity(currentSanity);
    }




    // Update is called once per frame
    void Update()
    {
        sanityCheck();
        if (Input.GetKeyDown(KeyCode.E))    //TODO Reed
        {
            currentElement = (element)Random.Range(0, 5);
            Debug.Log(currentElement);
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            increaseSanity(5);
            Debug.Log(currentSanity);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            decreaseSanity(10);
            Debug.Log(currentSanity);
        }
    }

    
    /**
     * Triggers methods in Event Manager to send out sanity events to other objects
     * 
     */
    private void sanityCheck()
    {
        if(currentSanity <= 25)
        {
            EventManager.underQuarterEventTrigger();
        }
        else if (currentSanity <= 50)
        {
            EventManager.underHalfEventTrigger();
        }
        else if(currentSanity <= 75)
        {
            EventManager.underThreeFourthsEventTrigger();
        }
        else
        {
            EventManager.fullSanityEventTrigger();
        }
    }
}
