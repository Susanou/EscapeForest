using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Transform transform;
    private int speed = 2;
    private Vector3 initialPos;
    private bool moved;
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        initialPos = transform.position;
        moved = false;
    }

    public void moveY(int distance)
    {
        //StartCoroutine(moveYOverTime(3));
        if (!moved)
        {
            transform.position = transform.position + Vector3.up * distance;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = gameObject.transform.position + Vector3.up * 1.5f;
            moved = true;
        }
    }

    public IEnumerator moveYOverTime(int distance)
    {
        yield return null;
    }





}
