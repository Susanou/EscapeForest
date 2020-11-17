using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHarm : MonoBehaviour
{

    [SerializeField] private float painValue;

    private GameObject playerObject;
    private BasePlayer player;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<BasePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Should be harming");
            collision.gameObject.GetComponent<BasePlayer>().addSanityOf(painValue);
            StartCoroutine(HarmAnimation(collision.gameObject));
        }
        
    }

    public IEnumerator HarmAnimation(GameObject wren)
    {
        wren.GetComponent<Animator>().SetBool("harm", true);
        yield return new WaitForSeconds(1);
        wren.GetComponent<Animator>().SetBool("harm", false);
    }
}
