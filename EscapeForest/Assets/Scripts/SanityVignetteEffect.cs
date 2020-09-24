using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class SanityVignetteEffect : MonoBehaviour
{
    Volume volume;
    Vignette vignette;
    private void OnEnable()
    {
        //TODO: shorten event manager calls
        EventManager.underQuarter += darkenQuarter;
        EventManager.underHalf += darkenHalf;
        EventManager.underThreeFourths += darkenThreeFourths;
        EventManager.fullSanity += darkenNone;

        volume = this.GetComponent<Volume>();
        Vignette effect;
        if (volume.profile.TryGet<Vignette>(out effect))
        {
            vignette = effect;
        }

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
        vignette.intensity.Override(0.75f);
    }
    private void darkenHalf()
    {
        vignette.intensity.Override(0.5f);
    }

    private void darkenThreeFourths()
    {
        vignette.intensity.Override(0.25f);
    }

    private void darkenNone()
    {
        vignette.intensity.Override(0f); ;
    }
}
