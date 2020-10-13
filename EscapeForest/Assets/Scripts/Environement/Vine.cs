using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    private BasePlayer player;
    [SerializeField] private GameObject lily;
    // Start is called before the first frame update
    void Start()
    {
        player = BasePlayer.instance;
        if(lily != null)
        {
            lily.SetActive(false);
        }
        
    }
    void OnMouseUp() // mouse click
{
        if (player.getCurrentElement() == BasePlayer.element.Water)
            lily.SetActive(true);
    }

    void OnTriggerEnter() // for trigger
    {
        if (player.getCurrentElement() == BasePlayer.element.Water)
            lily.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
