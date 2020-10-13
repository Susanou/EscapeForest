using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Specialized;
using System.Reflection;

//Animation
[RequireComponent(typeof(Animator))]
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

    //Varient effect
    [SerializeField] private bool isWaterToPit;
    [SerializeField] private float yOffset;

    //[SerializeField] private BooleanValue changePitColliderSize;
    //private Transform sanityPopupPrefab = Resources.Load("SanityPopUpPrefab") as Transform;

    [SerializeField] private Transform sanityPopupPrefab;


    private TextMeshPro textMesh;

    private Animator animator;
    private Animator playerAnimator;

    private GameObject playerObject;
    private BasePlayer player;

    private void Start() {
        //CreateSanityPopup(39);



        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<BasePlayer>();
        playerAnimator = playerObject.GetComponent<Animator>(); //BasePlayer script has no animator, have to go up to the Player object
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {

    }

    
    private void OnMouseDown() {
        
        DoInteraction();
    }

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
            if (KeyManager.km.HasKey())
            {
                KeyManager.km.UseKey();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
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
            //airObj.transform.localScale = gameObject.transform.localScale;
            /*if (airObj.GetComponent<Collider2D>() != null)
            {
                airObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
            }*/
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
          //  earthObj.transform.localScale = gameObject.transform.localScale;
            /*if (earthObj.GetComponent<Collider2D>() != null)
            {
                earthObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
            }*/
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
            Vector3 pos;
            if (isWaterToPit)
            {
                pos = gameObject.transform.position + Vector3.up * yOffset;
                Debug.Log(yOffset);
            }
            else
            {
                pos = this.transform.position;
            }

            GameObject fireObj = Instantiate(afterFire, pos, this.transform.rotation);

            if (isWaterToPit)
            {
                //TODO make this happen every time
                Vector2 waterColliderSize = gameObject.GetComponent<BoxCollider2D>().size;
                fireObj.GetComponent<BoxCollider2D>().size = waterColliderSize;
                
            }
         
            //fireObj.transform.localScale = gameObject.transform.localScale;
            /*    if(fireObj.<Collider2D>() != null)
                {
                    fireObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
                }
    */
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
            Vector3 pos;
            if (isWaterToPit)
            {
                pos = gameObject.transform.position + Vector3.up * yOffset;
                Debug.Log(yOffset);
            }
            else
            {
                pos = this.transform.position;
            }

            GameObject waterObj = Instantiate(afterWater, pos, transform.rotation);
           // waterObj.transform.localScale = gameObject.transform.localScale;
          /*  if (waterObj.GetComponent<Collider2D>() != null)
            {
                waterObj.GetComponent<Collider2D>().transform.localScale = gameObject.transform.localScale;
            }*/
            Destroy(this.gameObject);

        }

    }

    private void OnParticleCollision(GameObject other) {
        
        if(other.tag == "Magic"){
            Debug.Log("Magic happened");
            DoInteraction();
        }
    }

    private void OnParticleTrigger(GameObject other) {

        Debug.Log("trigger " + other.tag);

        if(other.tag == "Magic"){
            Debug.Log("Magic happened");
            DoInteraction();
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

    public void CreateSanityPopup(int cost)
    {

        if (sanityPopupPrefab != null) {
            textMesh = sanityPopupPrefab.GetComponent<TextMeshPro>();

            textMesh.SetText(cost.ToString());

            Transform sanityPopupTransform = Instantiate(sanityPopupPrefab, gameObject.transform.position, Quaternion.identity);

        }
    }
}
