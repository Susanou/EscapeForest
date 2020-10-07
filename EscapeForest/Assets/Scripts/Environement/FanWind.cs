using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanWind : MonoBehaviour
{
    bool fanOn = false;

    void OnTriggerStay2D(Collider2D col)
    {
        if (fanOn && (col.tag == "Player"))
        {
            col.attachedRigidbody.AddForce(new Vector2(1, 1), ForceMode2D.Impulse);
        }
    }

    public void FanTurnedOn()
    {
        fanOn = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
