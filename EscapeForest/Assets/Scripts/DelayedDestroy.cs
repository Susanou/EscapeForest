using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DelayedDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        float offset = -100000;

        Debug.Log("prefab loaded");

        s();

        Debug.Log("prefab destroyed");
        
        this.gameObject.transform.position = new Vector3(offset, 0, 0);
        */

        Destroy(this.gameObject, 1);
    }

    public IEnumerator s() {
        yield return new WaitForSeconds(1);
    }
}
