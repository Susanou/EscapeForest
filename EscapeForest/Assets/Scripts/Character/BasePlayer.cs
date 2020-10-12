using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Animation
[RequireComponent(typeof(Animator))]
public class BasePlayer : MonoBehaviour
{
    /**
     * Class for BasePlayer behavior and interactions wtih Sanity and elements
     * 
     * @author 
     * 
     */
    static BasePlayer _instance;
    public static BasePlayer instance {
        get {
            return _instance;
        }
    }
    private void Awake() {
        _instance = this;
    }

    public enum element {Air, Earth, Fire, Water, None};
    public ParticleSystem particle;

    public FloatValue currentSanity;
    public ElementValue currentElement;

    public Signal sanitySignal;
    public Signal elementChanged;

    // Sanity Variables
    private int maxSanity = 100;
    private int randomMovementThreshold = 10;
    private int randomElementThreshold = 15;
    //private int currentSanity = 100;
    [SerializeField] private SanityBar sanityBar;

    private bool randomMovementEnabled = false;
    private bool randomElementEnabled = false;

    private KeyCode[] inputKeyCodes = new[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };

    [SerializeField] private Element[] elementsArray = new Element[5];
    private Element usingElement;

    private void Start()
    {
        if(particle.isPlaying) particle.Stop();
        sanityBar.setSanity(this.getSanity());
        elementChanged.Raise();
        usingElement = elementsArray[(int)currentElement.RuntimeValue];
    }

    public element getCurrentElement()
    {
        return currentElement.RuntimeValue;
    }

    public float getSanity()
    {
        return currentSanity.RuntimeValue;
    }

    /**
     * Single method to adjust sanity, pass in a negative value to decrement
     * 
     */

    public void addSanityOf(int amount)
    {
        if(currentSanity.RuntimeValue + amount > maxSanity)
        {
            currentSanity.RuntimeValue = 100;
        }
        else if (currentSanity.RuntimeValue + amount < 0)
        {
            currentSanity.RuntimeValue = currentSanity.initialValue;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            currentSanity.RuntimeValue += amount;
        }
        sanityBar.setSanity(currentSanity.RuntimeValue);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentElement.RuntimeValue = (element)Random.Range(0, 5);
            usingElement = elementsArray[(int)currentElement.RuntimeValue];
            elementChanged.Raise();
        }

 
        if (Input.GetKeyDown(inputKeyCodes[0])) // Air = 1
        {
            currentElement.RuntimeValue = element.Air;
            usingElement = elementsArray[0];
            elementChanged.Raise();

        }
        else if (Input.GetKeyDown(inputKeyCodes[1])) // Earth = 2
        {
            currentElement.RuntimeValue = element.Earth;
            usingElement = elementsArray[1];
            elementChanged.Raise();

        }
        else if (Input.GetKeyDown(inputKeyCodes[2])) // Fire = 3
        {
            currentElement.RuntimeValue = element.Fire;
            usingElement = elementsArray[2];
            elementChanged.Raise();

        }
        else if (Input.GetKeyDown(inputKeyCodes[3])) // Water = 4
        {
            currentElement.RuntimeValue = element.Water;
            usingElement = elementsArray[3];
            elementChanged.Raise();
        }


        //TODO: Remember to refer the following two ifs in actual release
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            addSanityOf(1);
            sanitySignal.Raise();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            addSanityOf(-1);
            sanitySignal.Raise();
        }

        usingElement.OnRightClick();
        usingElement.OnLeftClickDrag(particle);
    }




    
    /**
     * Triggers methods in Event Manager to send out sanity events to other objects
     * 
     */
    public void sanityCheck()
    {
        //Random Movement Effect
        CharacterController characterController = this.GetComponentInParent<CharacterController>();

        if ((currentSanity.RuntimeValue < randomMovementThreshold)  && !randomMovementEnabled)
        {
            characterController.resetInputKeyCodes(true);
            randomMovementEnabled = true;
            Debug.Log("Random movement");
        }
        else if ((currentSanity.RuntimeValue >= randomMovementThreshold) && randomMovementEnabled)
        {
            characterController.resetInputKeyCodes(false);
            randomMovementEnabled = false;
            Debug.Log("Normal movement");
        }

        //Random Element Effect
        if ((currentSanity.RuntimeValue < randomElementThreshold) && !randomElementEnabled)
        {
            resetInputKeyCodes(true);
            randomElementEnabled = true;
            Debug.Log("Random elements");
        }
        else if ((currentSanity.RuntimeValue >= randomElementThreshold) && randomElementEnabled)
        {
            resetInputKeyCodes(false);
            randomElementEnabled = false;
            Debug.Log("Normal elements");
        }

    }

    private void resetInputKeyCodes(bool random)
    {
        if (!random)
        {
            inputKeyCodes = new[]  {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
        }
        else
        {
            int len = inputKeyCodes.Length;
            for (int i = 0; i < len - 1; i++)
            {
                int rnd = Random.Range(i, len);
                KeyCode temp = inputKeyCodes[rnd];
                inputKeyCodes[rnd] = inputKeyCodes[i];
                inputKeyCodes[i] = temp;
            }
        }
    }
}
