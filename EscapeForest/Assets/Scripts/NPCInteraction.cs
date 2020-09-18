using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction2 : MonoBehaviour
{
	/**
	 * Skeleton: Cameron
	 * New items: Talia
	 * Some (hopefully) refinements: Drew
	 * 
	 * Note: I wrote these changes with a slightly different design in mind. Instead of a prompt with a dropdown, assumed we could just change the text in the box.
	 *		The flow would be: Player walks up, prompt shows up, player can walk away and prompt will disappear. If player interacts while within range, text in 
	 *		prompt changes to be the hint, and the box still goes away/comes back as the players moves in/out of range. Can interact while hint is there to make it go away.
	 * */

	public string hint;
	public Text hintText; //Need to choose which one to use.
	public int sanityDecreaseValue;

	[SerializeField] private KeyCode interactKey;
	[SerializeField] private GameObject hintPrompt; //A Text object on the Canvas saying "Would you like to use a hint?" 

	private BasePlayer player;

	private bool touchingNPC = false;
	private bool hintUsed = false;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindObjectOfType<BasePlayer>();
	}

	// Update is called once per frame
	void Update()
	{
		if (touchingNPC)
		{
			if (Input.GetKey(KeyCode.Space) || Input.GetKey(interactKey))
			{
				Debug.Log(hint);
				Hint();
			}
		}
	}


	void OnTriggerEnter2D(Collider2D collision)
	{
		//If the player enters interaction range, make the hint/prompt show up
		if (collision.gameObject.tag == "NPC")
		{
			touchingNPC = true;
			hintPrompt.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		//If the player leaves, make the hint/prompt go away
		if (collision.gameObject.tag == "NPC")
		{
			touchingNPC = false;
			hintPrompt.SetActive(false);
		}


	}

	void Hint()
	{
		//The hint hasn't been used before
		if (!hintUsed)
		{
			hintText.text = hint; //Assuming hintText is the text, and hintPrompt is it's parent
			hintUsed = true;
			player.addSanityOf(-sanityDecreaseValue);//player.minusSanity(sanityDecreaseValue);
			hintPrompt.SetActive(true);
		}
		else
		{ //Hint has been used before
			hintPrompt.SetActive(false);
		}
	}
}
