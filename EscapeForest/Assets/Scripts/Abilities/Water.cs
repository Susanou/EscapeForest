using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{

    //water gun
    public override void OnLeftClickDrag(ParticleSystem particle, BasePlayer player) {
        if (Input.GetMouseButtonDown(0)) {
            if(!particle.isPlaying) particle.Play();
            player.addSanityOf(-this.universalCost);
            player.playerAudio.clip = this.audioEffect;
            player.playerAudio.Play();
        }

        if(Input.GetMouseButtonDown(0)) player.addSanityOf(-this.universalCost);

        if (Input.GetMouseButtonUp(0)) {
            if(particle.isPlaying) particle.Stop();
            particle.Clear();
            player.playerAudio.Stop();
        }
    }

    public override void OnRightClickDrag() {
        if (Input.GetMouseButton(1)) {
            Debug.Log("RightClick dragging");
        }
    }
}
