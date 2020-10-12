using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public static KeyManager km;
    public Image img;
    public int keys;
    private void Update()
    {
        if (keys >= 1)
        {
            img.gameObject.SetActive(true);
        }

        else img.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (km == null)
        {
            km = this;
        }
    }

    public void AddKey()
    {
        keys += 1;

        
    }

    public void UseKey()
    {
        if (keys <= 0)
        {
            Debug.Log("no key!");
        }
        else
        {
            keys -= 1;
        }
    }
    public bool HasKey()
    {
        if (keys >= 1)
        {
            return true;
        }
        else return false;
    }
}
