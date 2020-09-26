using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour

{
    [SerializeField] private int sanityCostAir;
    [SerializeField] private int sanityCostEarth;
    [SerializeField] private int sanityCostFire;
    [SerializeField] private int sanityCostWater;

    private Animator animator;

    private BasePlayer player;

    private void Start() {
        player = BasePlayer.instance;
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

    }

    
    private void OnMouseDown() {
        DoInteraction();
    }
    /*
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
        if (player.getCurrentElement() == BasePlayer.element.Air && gameObject.CompareTag("onAir"))
        {

            //This section to be replaced with "OnAir()";
            Debug.Log("DO AIR INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostAir.ToString());
            //animator.SetBool("air", true);
            gameObject.SetActive(false);
        }
        if (player.getCurrentElement() == BasePlayer.element.Earth && gameObject.CompareTag("onEarth"))
        {
            //This section to be replaced with "OnEarth()";
            Debug.Log("DO EARTH INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostEarth.ToString());
            //animator.SetBool("earth", true);
            gameObject.SetActive(false);
        }
        if (player.getCurrentElement() == BasePlayer.element.Fire && gameObject.CompareTag("onFire"))
        {
            //This section to be replaced with "OnFire()";
            Debug.Log("DO FIRE INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostFire.ToString());
            //animator.SetBool("fire", true);
            gameObject.SetActive(false);
        }
        if (player.getCurrentElement() == BasePlayer.element.Water && gameObject.CompareTag("onWater"))
        {
            //This section to be replaced with "OnWater()";
            Debug.Log("DO WATER INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostWater.ToString());
            //animator.SetBool("water", true);
            gameObject.SetActive(false);
        }

        if (gameObject.CompareTag("Door"))
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            
        }

    }

}
