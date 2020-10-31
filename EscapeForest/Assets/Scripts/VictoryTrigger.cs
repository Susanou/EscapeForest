using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryTrigger : MonoBehaviour
{
    private bool timeToWin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject finalText = GameObject.Find("TallSpirit");
        if(finalText.GetComponent<TextboxDialogue>() == null)
        {
            timeToWin = true;
        }

        if (timeToWin)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
