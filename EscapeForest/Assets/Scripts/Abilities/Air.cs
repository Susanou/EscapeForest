using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{

    private Rigidbody2D player;

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10};
        player = this.GetComponent<Rigidbody2D>();
    }

    public override void OnLeftClickDrag(ParticleSystem particle){
        if(Input.GetMouseButton(0)){
            if(!particle.isPlaying) particle.Play();
        }

        if(Input.GetMouseButtonUp(0)){
            if(particle.isPlaying) particle.Stop();
        }
    }

    public override void OnRightClick(){
        if(Input.GetMouseButtonDown(1)){
            this.player.gravityScale = 1f;
        }

        if (Input.GetMouseButtonUp(1)){
            this.player.gravityScale = 5f;
        }
    }
}
