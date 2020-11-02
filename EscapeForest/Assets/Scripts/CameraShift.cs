using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    [SerializeField] private float upperY;
    [SerializeField] private float lowerY;
    [SerializeField] private CameraMovement cameraMovementScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "FallThrough")
        {
            if (cameraMovementScript.getUpper())
            {
                cameraMovementScript.setYPos(lowerY);
                cameraMovementScript.setUpper(false);
            }
            else
            //switch to upper camera pos
            {
                cameraMovementScript.setYPos(upperY);
                cameraMovementScript.setUpper(true);
            }

        }
    }
}
