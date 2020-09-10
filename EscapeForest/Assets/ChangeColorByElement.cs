using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorByElement : MonoBehaviour
{
    SpriteRenderer spriteRenderer; 
    private void OnEnable()
    {
        EventManager.onNone += changeColorNone;
        EventManager.onAir += changeColorAir;
        EventManager.onEarth += changeColorEarth;
        EventManager.onFire += changeColorFire;
        EventManager.onWater += changeColorWater;

        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        EventManager.onNone -= changeColorNone;
        EventManager.onAir -= changeColorAir;
        EventManager.onEarth -= changeColorEarth;
        EventManager.onFire -= changeColorFire;
        EventManager.onWater -= changeColorWater;
    }

    private void changeColorNone()
    {
        spriteRenderer.color = Color.white;
    }
    private void changeColorAir()
    {
        spriteRenderer.color = Color.magenta;
    }

    private void changeColorEarth()
    {
        spriteRenderer.color = Color.black;
    }

    private void changeColorFire()
    {
        spriteRenderer.color = Color.red;
    }

    private void changeColorWater()
    {
        spriteRenderer.color = Color.blue;
    }
}
