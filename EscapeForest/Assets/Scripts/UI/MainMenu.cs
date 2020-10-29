using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private static int currentLevel = 0;

    public void PlayGame()
    {
        if (currentLevel == 0) {
            SceneManager.LoadScene("Tutorial");
        }
        else if (currentLevel == 1)
        {
            SceneManager.LoadScene("LevelSelect1");
        }
        else if (currentLevel == 2)
        {
            SceneManager.LoadScene("LevelSelect2");
        }
        else if (currentLevel == 3)
        {
            SceneManager.LoadScene("LevelSelect3");
        }
        else if (currentLevel == 4)
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ShowInstructions()
    {
        SceneManager.LoadScene("Instructions");  
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
            
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public static void IncreaseLevel()
    {
        currentLevel++;
    }

}
