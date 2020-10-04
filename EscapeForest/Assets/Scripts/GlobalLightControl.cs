using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLightControl : MonoBehaviour
{
    Light2D light;
    private void OnEnable()
    {
        EventManager.underQuarter += darkenQuarter;
        EventManager.underHalf += darkenHalf;
        EventManager.underThreeFourths += darkenThreeFourths;
        EventManager.fullSanity += darkenNone;

        light = this.GetComponentInParent<Light2D>();

    }

    private void OnDisable()
    {
        EventManager.underQuarter -= darkenQuarter;
        EventManager.underHalf -= darkenHalf;
        EventManager.underThreeFourths -= darkenThreeFourths;
        EventManager.fullSanity -= darkenNone;
    }


    private void darkenQuarter()
    {
        light.intensity = 0.25f;
    }
    private void darkenHalf()
    {
        light.intensity = 0.5f;
    }

    private void darkenThreeFourths()
    {
        light.intensity = 0.75f;
    }

    private void darkenNone()
    {
        light.intensity = 1;
    }

    private void logOnFire()
    {

    }
}
