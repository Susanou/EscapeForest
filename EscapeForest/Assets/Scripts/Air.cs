using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{

    [SerializeField] private ParticleSystem airGust;
    private Rigidbody2D player;

    public Air(ParticleSystem particule){
        airGust = particule;
    }

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10};
        player = this.GetComponent<Rigidbody2D>();
        airGust.Stop(); 
    }

    public override void OnLeftClickDrag(){
        if(Input.GetMouseButton(0)){
            airGust.Play();
        }

        if(Input.GetMouseButtonUp(0)){
            airGust.Play();
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

    public override void OnRightClickDrag(){
        if(Input.GetMouseButton(1)){
            Debug.Log("RightClick dragging");
        }
    }
}
