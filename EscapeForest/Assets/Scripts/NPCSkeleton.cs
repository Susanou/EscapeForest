using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSkeleton : MonoBehaviour
{

    public string hint;

    [SerializeField] private KeyCode interactKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Space)){
            Debug.Log(hint);
        }else if(Input.GetKey(interactKey)){
            Debug.Log(hint);
        }
        
    }
}
