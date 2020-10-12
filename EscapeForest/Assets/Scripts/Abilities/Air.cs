using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10};
    }

    public override void OnLeftClickDrag(ParticleSystem particle){
        if(Input.GetMouseButtonDown(0)){
            if(!particle.isPlaying) particle.Play();
        }

        if(Input.GetMouseButtonUp(0)){
            if(particle.isPlaying) particle.Stop();
            particle.Clear();
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
