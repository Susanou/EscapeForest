using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMove : MonoBehaviour
{
    
    [SerializeField] private GameObject toMove;
    [SerializeField] private bool up;
    [SerializeField] private bool right;
    [SerializeField] private int distance;
    
    private BasePlayer player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = BasePlayer.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnMouseDown()
    {
        if(up == true)
        {
           if (player.getCurrentElement() == BasePlayer.element.Air)
           {
            toMove.transform.position += Vector3.up*distance;
           }
        }
        
        if(right == true)
        {
            if (player.getCurrentElement() == BasePlayer.element.Air)
            {
             toMove.transform.position += Vector3.right*distance;
             player.transform.position += Vector3.right*distance;
             SceneManager.LoadScene("Victory");
             
            }
            
        }
   
    }
}