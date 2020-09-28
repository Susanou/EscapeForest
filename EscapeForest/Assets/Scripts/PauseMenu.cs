using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused = false;

    //Want to catch player gitting escape here
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!paused)
                Time.timeScale = 0; //Stops all time based movements. Update still gets called, but only non-time based movement will occur. Make sure player movement is time based!
            else
                Time.timeScale = 1;
            paused = !paused;
            pauseMenu.SetActive(paused);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = !paused;
        pauseMenu.SetActive(paused);
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
