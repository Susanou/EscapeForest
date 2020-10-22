using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Level4");
    }
}
