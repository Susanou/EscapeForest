using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_2 : MonoBehaviour
{
    private float length;
    private float startPosition;
    public GameObject cam;
    public float parallaxEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1-parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y,transform.position.z);
        if(temp > startPosition + length)
        {
            startPosition += length;
        }
        else if (temp < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
