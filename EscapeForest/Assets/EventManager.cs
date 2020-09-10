using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public delegate void ChangeElement();
    public static event ChangeElement changeElement;

    public static event ChangeElement onNone;
    public static event ChangeElement onAir;
    public static event ChangeElement onEarth;
    public static event ChangeElement onFire;
    public static event ChangeElement onWater;

    Dictionary<BasePlayer.element, ChangeElement> elementEvent = new Dictionary<BasePlayer.element, ChangeElement>();

    private void Start()
    {
        elementEvent.Add(BasePlayer.element.None, onNone);
        elementEvent.Add(BasePlayer.element.Air, onAir);
        elementEvent.Add(BasePlayer.element.Earth, onEarth);
        elementEvent.Add(BasePlayer.element.Fire, onFire);
        elementEvent.Add(BasePlayer.element.Water, onWater);
    }

    //TODO: Sanity Event
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BasePlayer.element currentElement = player.GetComponent<BasePlayer>().getCurrentElement();
            ChangeElement eventToCall = elementEvent[currentElement];


            if(eventToCall != null)
            {
                eventToCall();
            }
        }
    }
}
