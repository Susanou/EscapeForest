using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private Animator animator;

    private BasePlayer player;

    private void Start() {
        player = BasePlayer.instance;
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

<<<<<<< HEAD
            StartCoroutine(OnAir());

=======
            //This section to be replaced with "OnAir()";
            Debug.Log("DO AIR INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostAir.ToString());
            //animator.SetBool("air", true);
            gameObject.SetActive(false);
>>>>>>> Prefabs
        }
        if (player.getCurrentElement() == BasePlayer.element.Earth)
        {
<<<<<<< HEAD

            StartCoroutine(OnEarth());
=======
            //This section to be replaced with "OnEarth()";
            Debug.Log("DO EARTH INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostEarth.ToString());
            //animator.SetBool("earth", true);
            gameObject.SetActive(false);
>>>>>>> Prefabs
        }
        if (player.getCurrentElement() == BasePlayer.element.Fire)
        {
<<<<<<< HEAD
            StartCoroutine(OnFire());
=======
            //This section to be replaced with "OnFire()";
            Debug.Log("DO FIRE INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostFire.ToString());
            //animator.SetBool("fire", true);
            gameObject.SetActive(false);
>>>>>>> Prefabs
        }
        if (player.getCurrentElement() == BasePlayer.element.Water)
        {
<<<<<<< HEAD
            
            StartCoroutine(OnWater());
           
=======
            //This section to be replaced with "OnWater()";
            Debug.Log("DO WATER INTERACTION");
            Debug.Log("Sanity Changes by:" + sanityCostWater.ToString());
            //animator.SetBool("water", true);
            gameObject.SetActive(false);
>>>>>>> Prefabs
        }

        if (gameObject.CompareTag("Door"))
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            
        }

    }



    public IEnumerator OnAir()
    {
        player.addSanityOf(sanityCostAir);
        animator.SetBool("air", true);
        yield return new WaitForSeconds(airAnimationLength);

        if (destroyedByAir) {
            Instantiate(afterAir, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            
        }
       
    }

    public IEnumerator OnEarth()
    {
        player.addSanityOf(sanityCostEarth);
        animator.SetBool("earth", true);
        yield return new WaitForSeconds(earthAnimationLength);

        if (destroyedByEarth)
        {
            Instantiate(afterEarth, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }

    }

    public IEnumerator OnFire()
    {
        player.addSanityOf(sanityCostFire);
        animator.SetBool("fire", true);
        yield return new WaitForSeconds(fireAnimationLength);

        if (destroyedByFire)
        {
            Instantiate(afterFire, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }

    }

    public IEnumerator OnWater()
    {
        player.addSanityOf(sanityCostWater);
        animator.SetBool("water", true);
        yield return new WaitForSeconds(waterAnimationLength);

        if (destroyedByWater)
        {
            Instantiate(afterWater, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }

    }

}
