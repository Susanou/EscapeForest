using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private BasePlayer player;

    private void Start() {
        player = BasePlayer.instance;
    }

    private void Update()
    {

    }

    /*
    private void OnMouseDown() {
        DoInteraction();
    }

    public void DoInteraction()
    {
        if (player.getCurrentElement() == BasePlayer.element.Air) {
            Debug.Log("Air interaction");
        }
        else if (player.getCurrentElement() == BasePlayer.element.Water) {
            Debug.Log("Water interaction");
        }
        else if (player.getCurrentElement() == BasePlayer.element.Fire) {
            Debug.Log("Fire interaction");
            gameObject.SetActive(false);
        }
        else if (player.getCurrentElement() == BasePlayer.element.Earth) {
            Debug.Log("Earth interaction");
        }

    }
    */

    public void DoInteraction()
    {
        if (player.getCurrentElement().ToString() == "Air" && gameObject.CompareTag("onAir"))
        {
            Debug.Log("DO AIR INTERACTION");
            gameObject.SetActive(false);
        }
        if (player.getCurrentElement().ToString() == "Earth" && gameObject.CompareTag("onEarth"))
        {
            Debug.Log("DO EARTH INTERACTION");
            gameObject.SetActive(false);
        }
        if (player.getCurrentElement().ToString() == "Fire" && gameObject.CompareTag("onFire"))
        {
            Debug.Log("DO FIRE INTERACTION");
            gameObject.SetActive(false);
        }
        if (player.getCurrentElement().ToString() == "Water" && gameObject.CompareTag("onWater"))
        {
            Debug.Log("DO WATER INTERACTION");
            gameObject.SetActive(false);
        }

        if (gameObject.CompareTag("Door"))
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            
        }

    }

}
