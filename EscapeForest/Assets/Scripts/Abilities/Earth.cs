using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{

    public override void OnLeftClickDrag(ParticleSystem particle, BasePlayer player){
        if(Input.GetMouseButton(0)){
            if(!particle.isPlaying) particle.Play();
            player.addSanityOf(-this.universalCost);
            audio.Play();
        }

        if(Input.GetMouseButtonDown(0)) player.addSanityOf(-this.universalCost);

        if(Input.GetMouseButtonUp(0)){
            if(particle.isPlaying) particle.Stop();
            particle.Clear();
            audio.Stop();
        }
    }
}
