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

    private float speed = 25f;
    private int maxSanity = 100;
    public enum element { None,Air,Earth,Fire,Water};
    private element currentElement = element.None;

    private int currentSanity = 100;

    Transform playerTransform;

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
    }


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        sanityCheck();
        if (Input.GetKeyDown(KeyCode.E))
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
     * Basic Player movement
     * TODO improve
     * 
     */
    private void playerMovement()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            playerTransform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.position += Vector3.right * speed * Time.deltaTime;
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
