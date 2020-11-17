using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level2");
    }

    public void SnowArea()
    {
        SceneManager.LoadScene("SnowArea");
    }

    public void UpperForest()
    {
        SceneManager.LoadScene("UpperForest");
    }
}
