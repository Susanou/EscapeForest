using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveDistance;
    public float moveSpeed;

    private Vector3 initPos;


    private void Start()
    {
        initPos = gameObject.transform.position;
    }
    private void Update()
    {
        // floatin'
        transform.position = initPos + moveDir * (moveDistance * Mathf.Sin(Time.time * moveSpeed));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KeyManager.km.AddKey();
        }
    }
}
