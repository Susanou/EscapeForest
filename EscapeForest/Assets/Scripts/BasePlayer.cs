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

    public enum element { None,Air,Earth,Fire,Water};
    private element currentElement = element.None;

    public element getCurrentElement()
    {
        return currentElement;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentElement = (element)Random.Range(0, 5);
            Debug.Log(currentElement);
        }
    }
}
