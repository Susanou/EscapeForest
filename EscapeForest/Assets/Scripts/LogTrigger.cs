using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public BooleanValue onFire;

    private void Update()
    {
        if (this.GetComponent<InteractionObject>().getDestroyedByFire())
        {
            onFire.RuntimeValue = true;
        }
    }

}
