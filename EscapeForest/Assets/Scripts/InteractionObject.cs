using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Specialized;

public class InteractionObject : MonoBehaviour

{
    [SerializeField] private int sanityCostAir;
    [SerializeField] private int sanityCostEarth;
    [SerializeField] private int sanityCostFire;
    [SerializeField] private int sanityCostWater;

    [SerializeField] private float airAnimationLength;
    [SerializeField] private float earthAnimationLength;
    [SerializeField] private float fireAnimationLength;
    [SerializeField] private float waterAnimationLength;

    [SerializeField] private bool destroyedByAir;
    [SerializeField] private bool destroyedByEarth;
    [SerializeField] private bool destroyedByFire;
    [SerializeField] private bool destroyedByWater;

    [SerializeField] private GameObject afterAir;
    [SerializeField] private GameObject afterEarth;
    [SerializeField] private GameObject afterFire;
    [SerializeField] private GameObject afterWater;


    //Signals
    [SerializeField] private Signal onAirSignal;
    [SerializeField] private Signal onEarthSignal;
    [SerializeField] private Signal onFireSignal;
    [SerializeField] private Signal onWaterSignal;



    private Animator animator;
    private Animator playerAnimator;

    private GameObject playerObject;
    private BasePlayer player;

    private void Start() {
    

        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<BasePlayer>();
        playerAnimator = playerObject.GetComponent<Animator>(); //BasePlayer script has no animator, have to go up to the Player object
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    
    private void OnMouseDown() {
        DoInteraction();
    }
    /*
    public void DoInteraction()
    {
        if (player.getCurrentElement() == BasePlayer.element.Air) {
            Debug.Log("Air interaction");
        }
        else if (player.getCurrentElement() == BasePlayer.element.Water) {
            Debug.Log("Water interaction");
        }
        else if (player.getCurrentElement() == BasePlayer.element.Fire) {
            Debug.Log("Fire interaction");
            gameObject.SetActive(false);
        }
        else if (player.getCurrentElement() == BasePlayer.element.Earth) {
            Debug.Log("Earth interaction");
        }

    }
    */

    public void DoInteraction()
    {
        if (player.getCurrentElement() == BasePlayer.element.Air)
        {
            CreateSanityPopup(sanityCostAir);

            StartCoroutine(OnAir());
            

        }
        if (player.getCurrentElement() == BasePlayer.element.Earth)
        {

            CreateSanityPopup(sanityCostEarth);
            StartCoroutine(OnEarth());

        }
        if (player.getCurrentElement() == BasePlayer.element.Fire)
        {

            CreateSanityPopup(sanityCostFire);
            StartCoroutine(OnFire());
        }
        if (player.getCurrentElement() == BasePlayer.element.Water)
        {

            CreateSanityPopup(sanityCostWater);
            StartCoroutine(OnWater());
           

        }

        if (gameObject.CompareTag("Door"))
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            
        }

    }



    public IEnumerator OnAir()
    {
        playerAnimator.SetBool("usingElement", true);
        playerAnimator.SetBool("air", true);
        player.addSanityOf(sanityCostAir);
        animator.SetBool("air", true);
        yield return new WaitForSeconds(airAnimationLength);
        playerAnimator.SetBool("air", false);
        playerAnimator.SetBool("usingElement", false);

        if (onAirSignal != null)
        {
            onAirSignal.Raise();
        }

        if (destroyedByAir) {
            GameObject airObj = Instantiate(afterAir, this.transform.position, this.transform.rotation);

            if (airObj.GetComponent<Collider2D>() != null)
            {
                airObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
            }
            Destroy(this.gameObject);
            
        }
       
    }

    public IEnumerator OnEarth()
    {
        playerAnimator.SetBool("usingElement", true);
        playerAnimator.SetBool("earth", true);
        player.addSanityOf(sanityCostEarth);
        animator.SetBool("earth", true);
        yield return new WaitForSeconds(earthAnimationLength);
        playerAnimator.SetBool("earth", false);
        playerAnimator.SetBool("usingElement", false);

        if (onEarthSignal != null)
        {
            onEarthSignal.Raise();
        }
        if (destroyedByEarth)
        {
            GameObject earthObj = Instantiate(afterEarth, this.transform.position, this.transform.rotation);

            if (earthObj.GetComponent<Collider2D>() != null)
            {
                earthObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
            }
            Destroy(this.gameObject);

        }

    }

    public IEnumerator OnFire()
    {
        playerAnimator.SetBool("usingElement", true);
        playerAnimator.SetBool("fire", true);
        player.addSanityOf(sanityCostFire);
        animator.SetBool("fire", true);
        yield return new WaitForSeconds(fireAnimationLength);
        playerAnimator.SetBool("fire", false);
        playerAnimator.SetBool("usingElement", false);

        if (onFireSignal != null)
        {
            onFireSignal.Raise();
        }

        if (destroyedByFire)
        {

            GameObject fireObj = Instantiate(afterFire, this.transform.position, this.transform.rotation);

            if(fireObj.GetComponent<Collider2D>() != null)
            {
                fireObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
            }

            Destroy(this.gameObject);

        }

    }

    public IEnumerator OnWater()
    {
        playerAnimator.SetBool("usingElement", true);
        playerAnimator.SetBool("water", true);
        player.addSanityOf(sanityCostWater);
        animator.SetBool("water", true);
        yield return new WaitForSeconds(waterAnimationLength);
        playerAnimator.SetBool("water", false);
        playerAnimator.SetBool("usingElement", false);

        if (onWaterSignal != null)
        {
            onWaterSignal.Raise();
        }
        

        if (destroyedByWater)
        {
            GameObject waterObj = Instantiate(afterWater, transform.position, transform.rotation);
            waterObj.transform.localScale = gameObject.transform.localScale;
            if (waterObj.GetComponent<Collider2D>() != null)
            {
                waterObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
            }
            Destroy(this.gameObject);

        }

    }



    public bool getDestroyedByAir()
    {
        return destroyedByAir;
    }

    public bool getDestroyedByEarth()
    {
        return destroyedByEarth;
    }

    public bool getDestroyedByFire()
    {
        return destroyedByFire;
    }

    public bool getDestroyedByWater()
    {
        return destroyedByWater;
    }

    public void CreateSanityPopup(int sanityCost)
    {
        //This was omitted by accident somehow when Orion pushed so I'm leaving it blank for now cause I don't know
        //what was in it
    }

}
