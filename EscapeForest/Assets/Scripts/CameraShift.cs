using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraShift : MonoBehaviour
{
    [SerializeField] private FloatValue shift;
    private string currentScene;
    private bool L1up = false;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collide");
        if (other.gameObject.tag == "Player")
        {
            switch (currentScene)
            {
                case "Tutorial":
                    shift.RuntimeValue = 10f;
                    break;
                case "Level1":
                    if(!L1up)
                    {
                        shift.RuntimeValue = 18f;
                        L1up = true;
                    }
                    else
                    {
                        shift.RuntimeValue = -2f;
                        L1up = false;
                    }
                    
                    break;
                case "Level1Upper":

                    break;
                case "Level2":

                    break;
                case "Level3":

                    break;
                case "Level4":
                    shift.RuntimeValue = 9f;
                    break;
                default:
                    shift.RuntimeValue = 0;
                    break;
            }
            Debug.Log(L1up);
        }
    }
}
