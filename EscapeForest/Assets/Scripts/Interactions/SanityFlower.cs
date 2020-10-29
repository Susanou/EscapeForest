using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityFlower : MonoBehaviour
{

    public float sanityGain;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag == "Player");

        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<BasePlayer>().addSanityOf(sanityGain);
            this.gameObject.SetActive(false);
        }
    }
}
