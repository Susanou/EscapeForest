using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class Mute : MonoBehaviour
{
    Toggle muteToggle;
    // Start is called before the first frame update
    void Start()
    {
        muteToggle = GetComponent<Toggle>();
        if(AudioListener.volume == 0)
        {
            muteToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ToggleAudio(bool audio)
    {
        if(audio)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}
