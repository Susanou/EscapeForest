using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSanityOnCollide : MonoBehaviour
{

    private BasePlayer playerScript;

    //Set the costs (in inspector) of interacting with this object for different elements
    [SerializeField] private int[] setSanityCosts = new int[4]; //TODO change names of array elements in inspector

    Dictionary<BasePlayer.element, int> sanityCosts = new Dictionary<BasePlayer.element, int>(); //none air earth fire water



    // Start is called before the first frame update
    void Start()
    {
        sanityCosts.Add(BasePlayer.element.None, 0);
        sanityCosts.Add(BasePlayer.element.Air, setSanityCosts[1]);
        sanityCosts.Add(BasePlayer.element.Earth, setSanityCosts[2]);
        sanityCosts.Add(BasePlayer.element.Fire, setSanityCosts[3]);
        sanityCosts.Add(BasePlayer.element.Water, setSanityCosts[4]);

        playerScript = GameObject.Find("Player").GetComponent<BasePlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(sanityCosts[playerScript.getCurrentElement()]);
        playerScript.addSanityOf(sanityCosts[playerScript.getCurrentElement()]);
    }


}
