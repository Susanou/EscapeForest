using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxDialogue : MonoBehaviour
{
	
	[SerializeField] private string[] dialogue;
	[SerializeField] private Image textbox;
	[SerializeField] private Text nameText;
	[SerializeField] private Text dialogueText;
	[SerializeField] private CharacterController controls; //put the player here

	public bool reocurring;

	private int convoLength;
	private bool convoStarted;
	private bool convoEnded;
	private int convoComponent;


	void Start()
	{
		controls = GameObject.Find("Player").GetComponent<CharacterController>();
		convoLength = dialogue.Length;
		convoStarted = false;
		convoEnded = false;

	}


	void Update()
	{

		if (convoStarted & !convoEnded)
		{
			textbox.enabled = true;
			nameText.enabled = true;
			dialogueText.enabled = true;


			dialogueText.text = dialogue[convoComponent];

			if (Input.GetKeyDown(KeyCode.F))
			{
				convoComponent++;
			}

			if (convoComponent >= convoLength)
			{
				convoEnded = true;
			}
		}

		if (convoEnded)
		{
			controls.enabled = true;
			textbox.enabled = false;
			nameText.enabled = false;
			dialogueText.enabled = false;


			if (!reocurring)
			{
				Debug.Log("Destroying conversation: " + this.gameObject.name);
				Destroy(this);
			}
		}


	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			convoStarted = true;
			controls.enabled = false;
			convoEnded = false;
			convoComponent = 0;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			convoEnded = true;
			convoStarted = false;
		}
	}

	public string[] getDialogues(){
		return this.dialogue;
	}
}
