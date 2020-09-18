using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private BasePlayer player;
    private void Start() {
        player = BasePlayer.instance;
    }
    private void OnMouseDown() {
        DoInteraction();
    }
    // James
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
}
