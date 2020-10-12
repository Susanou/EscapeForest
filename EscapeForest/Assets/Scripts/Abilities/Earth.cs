using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10};
    }

    public override void OnLeftClickDrag(ParticleSystem particle){
        if(Input.GetMouseButton(0)){
            if(!particle.isPlaying) particle.Play();
        }

        if(Input.GetMouseButtonUp(0)){
            if(particle.isPlaying) particle.Stop();
            particle.Clear();
        }
    }
}
