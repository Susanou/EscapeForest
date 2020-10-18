using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float camX;
    [SerializeField] private float camY;
    [SerializeField] private float camZ;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 cameraOffset = new Vector3(camX, camY, camZ);
        gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position + cameraOffset;
    }

}
