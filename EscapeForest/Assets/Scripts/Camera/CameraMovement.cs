using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    private float yPos;
    private string currentScene;
    private bool upper = false;
    private float correction = 0; //correct movement in camera



    public void setYPos(float newPos)
    {
        yPos = newPos;
    }

    public bool getUpper()
    {
        return upper;
    }

    public void setUpper(bool newValue)
    {
        upper = newValue;
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "Tutorial":
                yPos = 0.5f;
                break;
            case "Level1":
                yPos = -1f;
                correction = 1.5f;
                break;
   
            case "SnowArea":
                yPos = 25;
                break;
            case "Level3":

                break;
            case "Level4":
                yPos = 2f;
                break;
            default:
                yPos = 0;
                break;
        }
    }




    private void LateUpdate()
    {
        
        Camera.main.transform.position = new Vector3(transform.position.x, yPos-correction, transform.position.z);
    }


}
