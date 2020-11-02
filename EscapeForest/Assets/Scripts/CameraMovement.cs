using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    private float yPos;
    private string currentScene;
    private bool upper = false;

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
                yPos = 10f;
                break;
            case "Level1":
                yPos = -1f;
                break;
            case "Level1Upper":

                break;
            case "Level2":

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
        Debug.Log(yPos);
        Camera.main.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

}
