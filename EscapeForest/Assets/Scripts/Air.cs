using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{

    [SerializeField] private GameObject gust;

    private void Start() {
        sanityCosts = new int[8] { 0, 0, 5, 5, -5, 5, -5, -10};
    }

    public override void OnLeftClickDrag(){
        if(Input.GetMouseButton(0)){
            Debug.Log("LeftClick dragging");
        }
    }

    public override void OnRightClick(){
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("RightClick pressed");
        }
    }

    public override void OnRightClickDrag(){
        if(Input.GetMouseButton(1)){
            Debug.Log("RightClick dragging");
        }
    }
}
