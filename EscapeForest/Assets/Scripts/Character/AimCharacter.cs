using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCharacter : MonoBehaviour
{

    private Transform aimTransform;

    // Start is called before the first frame update
    void Start()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouspos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        Vector3 aimdir = (mouspos - transform.position).normalized;
        float angle = Mathf.Atan2(aimdir.y, aimdir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Debug.DrawLine(aimTransform.position, aimdir * 100, Color.cyan);
    }
}
