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
    [SerializeField] private Transform playerTransform;

    private float speed = 25f;
    public enum element { None,Air,Earth,Fire,Water};
    private element currentElement = element.None;

    //TODO Sanity
    private int sanityLevel = 25;

    public element getCurrentElement()
    {
        return currentElement;
    }

    public int getSanity()
    {
        return sanityLevel;
    }

    public void increaseSanity(int amount)
    {
        sanityLevel += amount;
    }

    public void decreaseSanity(int amount)
    {
        if (sanityLevel -amount < 0)
        {
            sanityLevel = 0;
        }
        else
        {
            sanityLevel -= amount;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentElement = (element)Random.Range(0, 5);
            Debug.Log(currentElement);
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            increaseSanity(5);
            Debug.Log(sanityLevel);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            decreaseSanity(10);
            Debug.Log(sanityLevel);
        }
    }

    private void playerMovement()
    {
        Vector2 pos = playerTransform.position;

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
}
