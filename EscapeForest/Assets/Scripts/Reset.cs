using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private BasePlayer player;
    [SerializeField] private float resetX;
    [SerializeField] private float resetY;
    [SerializeField] private float resetZ;

    // Start is called before the first frame update
    void Start()
    {
        player = BasePlayer.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            player.addSanityOf(-20);
            player.transform.position = new Vector3(resetX, resetY, resetZ);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
