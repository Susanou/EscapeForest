using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Transform transform;
    private int speed = 2;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        initialPos = transform.position;
    }

    public void moveY(int distance)
    {
        //StartCoroutine(moveYOverTime(3));
        transform.position = transform.position + Vector3.up * distance;
    }

    public IEnumerator moveYOverTime(int distance)
    {
        yield return null;
    }
}
