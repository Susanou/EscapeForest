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

    // Sanity Variables
    private int maxSanity = 100;
    private int randomMovementThreshold = 10;
    private int randomElementThreshold = 15;
    private int currentSanity = 100;
    [SerializeField] private SanityBar sanityBar;

    private bool randomMovementEnabled = false;
    private bool randomElementEnabled = false;

    //Element variables
    public enum element { None,Air,Earth,Fire,Water};
    private element currentElement = element.None;

    private KeyCode[] inputKeyCodes = new[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    


    public element getCurrentElement()
    {
        return currentElement;
    }

    public int getSanity()
    {
        return currentSanity;
    }


    /**
     * Single method to adjust sanity, pass in a negative value to decrement
     * 
     */

    public void addSanityOf(int amount)
    {
        if((currentSanity += amount) > maxSanity)
        {
            currentSanity = 100;
        }
        else if (currentSanity - amount < 0)
        {
            currentSanity = 0;
        }
        else
        {
            currentSanity += amount;
        }
        sanityBar.setSanity(currentSanity);
    }

/*    public void minusSanity(int amount){
        if (currentSanity - amount < 0)
        {
            currentSanity = 0;
        }
        else
        {
            currentSanity -= amount;
        } 
        sanityBar.setSanity(currentSanity);
    }*/



    // Update is called once per frame
    void Update()
    {
        sanityCheck();
        if (Input.GetKeyDown(KeyCode.E))    //TODO Reed
        {
            currentElement = (element)Random.Range(0, 5);
            Debug.Log(currentElement);

        }

 
        if (Input.GetKeyDown(inputKeyCodes[0]))
        {
            currentElement = element.Air;
            Debug.Log(currentElement);
        }
        if (Input.GetKeyDown(inputKeyCodes[1]))
        {
            currentElement = element.Earth;
            Debug.Log(currentElement);
        }
        if (Input.GetKeyDown(inputKeyCodes[2]))
        {
            currentElement = element.Fire;
            Debug.Log(currentElement);
        }
        if (Input.GetKeyDown(inputKeyCodes[3]))
        {
            currentElement = element.Water;
            Debug.Log(currentElement);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            addSanityOf(1);
            Debug.Log(currentSanity);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            addSanityOf(-1);
            Debug.Log(currentSanity);
        }
        
    
        
        
    }




    
    /**
     * Triggers methods in Event Manager to send out sanity events to other objects
     * 
     */
    private void sanityCheck()
    {
        //Random Movement Effect
        CharacterController characterController = this.GetComponentInParent<CharacterController>();

        if ((currentSanity < randomMovementThreshold)  && !randomMovementEnabled)
        {
            characterController.resetInputKeyCodes(true);
            randomMovementEnabled = true;
            Debug.Log("Random movement");
        }
        else if ((currentSanity >= randomMovementThreshold) && randomMovementEnabled)
        {
            characterController.resetInputKeyCodes(false);
            randomMovementEnabled = false;
            Debug.Log("Normal movement");
        }

        //Random Element Effect
        if ((currentSanity < randomElementThreshold) && !randomElementEnabled)
        {
            resetInputKeyCodes(true);
            randomElementEnabled = true;
            Debug.Log("Random elements");
        }
        else if ((currentSanity >= randomElementThreshold) && randomElementEnabled)
        {
            resetInputKeyCodes(false);
            randomElementEnabled = false;
            Debug.Log("Normal elements");
        }



        //Scene changes at sanity thresholds 
        if (currentSanity <= 25)
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

    private void resetInputKeyCodes(bool random)
    {
        if (!random)
        {
            inputKeyCodes = new[]  {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
        }
        else
        {
            int len = inputKeyCodes.Length;
            for (int i = 0; i < len - 1; i++)
            {
                int rnd = Random.Range(i, len);
                KeyCode temp = inputKeyCodes[rnd];
                inputKeyCodes[rnd] = inputKeyCodes[i];
                inputKeyCodes[i] = temp;
            }
        }
    }
}
