using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private FloatValue yPos;
    private string currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "Tutorial":
                yPos.initialValue = 10f;
                break;
            case "Level1":
                yPos.initialValue = -2f;
                break;
            case "Level1Upper":

                break;
            case "Level2":

                break;
            case "Level3":

                break;
            case "Level4":
                yPos.initialValue = 2f;
                break;
            default:
                yPos.initialValue = 0;
                break;
        }
        Debug.Log(yPos.RuntimeValue);
    }




    private void LateUpdate()
    {
        Debug.Log(yPos.RuntimeValue);
        Camera.main.transform.position = new Vector3(transform.position.x, yPos.RuntimeValue, transform.position.z);
    }

}
