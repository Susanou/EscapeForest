using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
	/**
	 * Skeleton: Cameron
	 * New items: Talia
	 * 
	 * Note: I implemented a Dropdown object for selecting if the player would like a hint, but we can
	 * change this to buttons or another method of choosing later on down the road if need be
	 * */

	public string hint;
	public int sanityDecreaseValue;

	[SerializeField] private KeyCode interactKey;
	[SerializeField] private GameObject hintPrompt; //A Text object on the Canvas saying "Would you like to use a hint?" with a Dropdown child of options "yes" and "no"
	[SerializeField] private Dropdown hintOptions; //The aforementioned Dropdown child
	[SerializeField] private Text hintText;

	private bool touchingNPC = false;
	private bool hintUsed = false;

	// Start is called before the first frame update
	void Start()
	{

		hintText.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (touchingNPC) {
			if (Input.GetKey (KeyCode.Space) || Input.GetKey(interactKey)) {
				Debug.Log (hint);
				Hint ();
			}
		}

		if (hintOptions.value == 1) {// player has selected "Yes"
			hintUsed = true;
			hintPrompt.SetActive (false);
			Hint ();

		} else if (hintOptions.value == 2) { //player has selected "No."
			hintPrompt.SetActive(false);
			hintOptions.value = 0; //Resets the dropdown menu to "select"
		}

	}


	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "NPC") {
			touchingNPC = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision){
		if (collision.gameObject.tag == "NPC") {
			touchingNPC = false;
		}


	}

	void Hint(){

		if (!hintUsed) {
			hintPrompt.SetActive (true);
		} else {
			hintText.text = hint;
			hintText.enabled = true;
			FindObjectsOfType<BasePlayer> () [0].DecreaseSanity (sanityDecreaseValue); //there should only be one game object in scene with BasePlayer attribute, but we can change this to a serialized field later if need be
			}
		/**
		 * I am also struggling to find a way to make it so that the hint goes away on a click/button press but reappears when
		 * the player returns to the spirit NPC and clicks/presses button again
		 * */
			
		}
		

}
