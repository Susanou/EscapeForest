using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    private BasePlayer playerScript;
    public Slider slider;

    public void Start()
    {
        slider.value = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>().getSanity();
    }

    public void setSanity(float sanity)
    {
        slider.value = sanity;
    }
}
