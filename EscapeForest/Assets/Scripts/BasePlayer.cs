using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{

    private enum element { None,Air,Earth,Fire,Water};
    private element currenElement = element.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currenElement = (element)Random.Range(0, 4);
            Debug.Log(currenElement);
        }
    }
}
