using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalControl : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject background;
    [SerializeField] private float upperY;
    [SerializeField] private float lowerY;
    [SerializeField] private float triggerY;

    private bool shiftedBackground = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = background.transform.position;

        if (player.GetComponent<Transform>().position.y > triggerY)
        {
            Camera.main.GetComponent<CameraMovement>().setYPos(upperY);
            if (!shiftedBackground)
            {
                moveBackground(upperY - lowerY);
                shiftedBackground = true;
            }
            
        }
        else
        {
            Camera.main.GetComponent<CameraMovement>().setYPos(lowerY);

            if (shiftedBackground)
            {
                resetBackground();
                shiftedBackground = false;
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
