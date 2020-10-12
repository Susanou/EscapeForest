using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    private Rigidbody2D player;

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10 };
        player = this.GetComponent<Rigidbody2D>();
    }


    //TODO check 2nd ability
    //change state of object
    public override void OnRightClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            Debug.Log(hit.transform.gameObject.name);
            hit.transform.gameObject.tag = "Ice";
        }
    }
    //water gun
    public override void OnLeftClickDrag(ParticleSystem particle) {
        if (Input.GetMouseButtonDown(0)) {
            if(!particle.isPlaying) particle.Play();
        }

        if (Input.GetMouseButtonUp(0)) {
            if(particle.isPlaying) particle.Stop();
            particle.Clear();
        }
    }
    //fireball
    public override void OnLeftClick() {
        if (Input.GetMouseButton(1) || Input.GetMouseButtonUp(1)) {
            launchWaterBall();
        }
    }

    //send fireball from player
    public void launchWaterBall() {

    }

    public override void OnRightClickDrag() {
        if (Input.GetMouseButton(1)) {
            Debug.Log("RightClick dragging");
        }
    }
}
