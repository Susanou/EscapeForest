using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class SanityVignetteEffect : MonoBehaviour
{
    /*Volume volume;
    Vignette vignette;*/

    Image vignette;
    Color newColor;

    BasePlayer player;
    float reduction = 0.4f;
  /*  private void OnEnable()
    {
        
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
*/


    //Alternate implementaiton
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        vignette = this.gameObject.GetComponent<Image>();
        /*volume = this.GetComponent<Volume>();
        Vignette effect;
        if (volume.profile.TryGet<Vignette>(out effect))
        {
            vignette = effect;
        }*/
    }
    private void Update()
    {
        float alpha = (1f - (player.getSanity() / 100));  //Higher alpha for less sanity
        newColor = new  Color(vignette.color.r, vignette.color.g, vignette.color.b, alpha);
        vignette.color = newColor;
    }
}
