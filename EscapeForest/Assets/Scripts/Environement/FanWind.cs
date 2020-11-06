using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanWind : MonoBehaviour
{
    [SerializeField] private float xThrust = 1;
    [SerializeField] private float yThrust = 1;

    bool fanOn = false;

    public void Start()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (fanOn && (col.tag == "Player"))
        {

            col.attachedRigidbody.AddForce(new Vector2(xThrust, yThrust), ForceMode2D.Impulse);
            StartCoroutine(WrenFly(col.gameObject));
        }
    }

    public void FanTurnedOn()
    {
        fanOn = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public IEnumerator WrenFly(GameObject wren)
    {

        wren.GetComponent<Animator>().SetBool("usingElement", true);
        wren.GetComponent<Animator>().SetBool("air", true);
        yield return new WaitForSeconds(1);
        wren.GetComponent<Animator>().SetBool("air", false);
        wren.GetComponent<Animator>().SetBool("usingElement", false);

    }
}
