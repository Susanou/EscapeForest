﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
    [SerializeField] private GameObject light;

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10 };
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
            particle.Play();
        }

        if (Input.GetMouseButtonUp(0)) {
            particle.Play();
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
