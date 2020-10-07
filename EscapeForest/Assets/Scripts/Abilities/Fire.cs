using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{

    [SerializeField] private ParticleSystem flamethrower;
    [SerializeField] private ParticleSystem fireball;
    [SerializeField] private GameObject light;
    private Rigidbody2D player;

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10 };
        player = this.GetComponent<Rigidbody2D>();
    }



    //light
    public override void OnRightClick() {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(1)) {
            if (light.activeInHierarchy == true)
                light.SetActive(false);
            else
                light.SetActive(true);
        }
    }
    //flamethrower
    public override void OnLeftClickDrag(ParticleSystem particle) {
        if (Input.GetMouseButton(0)) {
            flamethrower.Play();
        }

        if (Input.GetMouseButtonUp(0)) {
            flamethrower.Play();
        }
    }
    //fireball
    public override void OnLeftClick() {
        if (Input.GetMouseButton(1) || Input.GetMouseButtonUp(1)) {
            launchFireBall();
        }
    }

    //send fireball from player
    public void launchFireBall() {

    }

    public override void OnRightClickDrag() {
        if (Input.GetMouseButton(1)) {
            Debug.Log("RightClick dragging");
        }
    }
}
