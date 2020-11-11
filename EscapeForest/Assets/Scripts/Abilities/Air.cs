using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    public override void OnLeftClickDrag(ParticleSystem particle, BasePlayer player){

        if(Input.GetMouseButtonDown(0)){
            if(!particle.isPlaying) particle.Play();
            player.addSanityOf(-this.universalCost);
            GetComponent<AudioSource>().Play();
        }

        if(Input.GetMouseButton(0)){
            player.addSanityOf(-this.universalCost);
        }

        if(Input.GetMouseButtonUp(0)){
            if(particle.isPlaying) particle.Stop();
            particle.Clear();
            GetComponent<AudioSource>().Stop();
        }
    }

    public override void OnRightClick(){

        Rigidbody2D player = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        if(Input.GetMouseButtonDown(1)){
            player.gravityScale = 1f;
        }

        if (Input.GetMouseButtonUp(1)){
            player.gravityScale = 5f;
        }
    }
}
