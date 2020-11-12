using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{

    public GameObject audio;
    private AudioSource footsteps;

    // Start is called before the first frame update
    void Start()
    {
        footsteps = audio.GetComponent<AudioSource>();
        //footsteps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
