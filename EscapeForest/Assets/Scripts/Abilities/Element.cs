using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Element : MonoBehaviour
{
    
    public float universalCost = 0.01f;

    public AudioClip audioEffect;
    public AudioSource playerAudio;

    public virtual void OnLeftClick(){
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("LeftClick pressed");
        }
    }

    public virtual void OnLeftClickDrag(ParticleSystem particule, BasePlayer player){
        if(Input.GetMouseButton(0)){
            Debug.Log("LeftClick dragging");
        }
    }

    public virtual void OnRightClick(){
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("RightClick pressed");
        }
    }

    public virtual void OnRightClickDrag(){
        if(Input.GetMouseButton(1)){
            Debug.Log("RightClick dragging");
        }
    }

}
