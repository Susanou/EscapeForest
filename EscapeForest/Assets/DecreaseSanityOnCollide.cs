using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSanityOnCollide : MonoBehaviour
{

    private BasePlayer playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<BasePlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript.decreaseSanity(5);
    }


}
