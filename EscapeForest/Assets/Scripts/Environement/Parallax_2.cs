using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_2 : MonoBehaviour
{
    private float length;
    private float initialX;
    public GameObject cam;
    public float parallaxEffect;

    private Vector3 startPos;
    private float initialY;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        initialX = transform.position.x;
        initialY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    //Shifting camera in tutorial
    public void changeY(float newY)
    {
        startPos.y = startPos.y + newY;
    }


    public void resetY()
    {
        startPos.y = initialY;
    }

    void FixedUpdate()
    {
        Debug.Log(startPos.y);
        float temp = (cam.transform.position.x * (1-parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(initialX + distance,startPos.y,transform.position.z);
        if(temp > initialX + length)
        {
            initialX += length;
        }
        else if (temp < initialX - length)
        {
            initialX -= length;
        }
    }
}
