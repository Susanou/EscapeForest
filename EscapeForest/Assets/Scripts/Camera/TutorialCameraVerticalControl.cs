using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCameraVerticalControl : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject background;
    [SerializeField] private float upperY;
    [SerializeField] private float lowerY;
    [SerializeField] private float initialY;
    [SerializeField] private float triggerYLower;
    [SerializeField] private float triggerYUpper;

    private bool shiftedBackgroundUp = false;
    private bool shiftedBackgroundDown = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;

        if (pos.y >= triggerYUpper)
        {
            Camera.main.GetComponent<CameraMovement>().setYPos(upperY);
            if (!shiftedBackgroundUp)
            {
                moveBackground(upperY);
                shiftedBackgroundUp = true;
            }

        }
        else if (pos.y <= triggerYLower)
        {
            Camera.main.GetComponent<CameraMovement>().setYPos(lowerY);
            if (!shiftedBackgroundDown)
            {
                moveBackground(lowerY);
                shiftedBackgroundDown = true;
            }
        }
        else if(triggerYLower < pos.y && pos.y < triggerYUpper)
        {
            Camera.main.GetComponent<CameraMovement>().setYPos(initialY);

            if (shiftedBackgroundUp)
            {
                resetBackground();
                shiftedBackgroundUp = false;
                shiftedBackgroundDown = false;
            }
        }
    }

    private void moveBackground(float yPos)
    {
        Component[] scripts = background.GetComponentsInChildren<Parallax_2>();

        foreach (Parallax_2 script in scripts)
        {
            script.changeY(yPos);
            
        }
    }

    private void resetBackground()
    {
        Component[] scripts = background.GetComponentsInChildren<Parallax_2>();

        foreach (Parallax_2 script in scripts)
        {
            script.resetY();
        }
    }



}
