using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    private BasePlayer playerScript;
    public Slider slider;

    public void setSanity(float sanity)
    {
        slider.value = sanity;
    }
}
