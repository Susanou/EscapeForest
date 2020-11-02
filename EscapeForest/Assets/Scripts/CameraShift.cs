using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    [SerializeField] private float upperY;
    [SerializeField] private float lowerY;
    [SerializeField] private CameraMovement cameraMovementScript;
    [SerializeField] private GameObject background;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "FallThrough")
        {
            if (cameraMovementScript.getUpper())
            {
                cameraMovementScript.setYPos(lowerY);
                cameraMovementScript.setUpper(false);
                resetBackground();
            }
            else
            //switch to upper camera pos
            {
                cameraMovementScript.setYPos(upperY);
                cameraMovementScript.setUpper(true);
                moveBackground(upperY-lowerY);
            }

        }
    }

    private void moveBackground(float yPos)
    {
        Component[] scripts = background.GetComponentsInChildren<Parallax>();

        foreach (Parallax script in scripts)
        {
            script.changeY(yPos);
        }
    }

    private void resetBackground()
    {
        Component[] scripts = background.GetComponentsInChildren<Parallax>();

        foreach (Parallax script in scripts)
        {
            script.resetY();
        }
    }
}
