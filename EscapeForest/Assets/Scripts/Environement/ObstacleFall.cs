using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    public int movespeed = 10;
    [SerializeField] GameObject obstacle;
    
    void Update()
    {
        Vector3 Direction = Vector3.down;
        obstacle.transform.Translate(Direction * movespeed * Time.deltaTime);
    }
}
