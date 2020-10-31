using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    private float yPos;
    private string currentScene;

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

                break;
            default:
                yPos = 0;
                break;
        }
        Debug.Log(yPos);
    }



    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

}
