﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySpirits : MonoBehaviour
{
	//[SerializeField] private string[] names;
	[SerializeField] private string[] dialogue;
	[SerializeField] private Image textbox;
	[SerializeField] private Text nameText;
	[SerializeField] private Text dialogueText;
    private CharacterController controls; 
	private int convoLength;
	private bool convoStarted;
	private bool convoEnded;
	private int convoComponent;


	void Start()
	{
		controls = GameObject.FindObjectOfType<CharacterController>();
		convoLength = dialogue.Length;
		convoStarted = false;
		convoEnded = false;
        convoComponent = 0;
	}


	void Update()
	{

		if (convoStarted)
		{
            Debug.Log("Spirit story enabled");
			textbox.enabled = true;
			nameText.enabled = true;
			dialogueText.enabled = true;

			//nameText.text = names[convoComponent];
			dialogueText.text = dialogue[convoComponent];

			if (Input.GetKeyDown(KeyCode.F))
			{
				convoComponent++;
                controls.enabled = false;
			}

			if (convoComponent >= convoLength)
			{
				controls.enabled = true;
				convoComponent = 0;
				convoStarted = false;
				textbox.enabled = false;
				nameText.enabled = false;
				dialogueText.enabled = false;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			convoStarted = true;
			convoComponent = 0;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			convoStarted = false;
            textbox.enabled = false;
			nameText.enabled = false;
			dialogueText.enabled = false;
		}
	}
}