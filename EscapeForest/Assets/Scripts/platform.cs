using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    [SerializeField] private bool endless;
    private bool moveOnce = false;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (endless)
        {
            endlessMove();
        }
        else if (moveOnce )
        {
            Vector3 destination = pos2.transform.position;
            if(transform.position == destination)
            {
                moveOnce = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime); 

        }

        
    }

    public void triggerMoveOnce()
    {
        moveOnce = true;
    }
    private void endlessMove()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
