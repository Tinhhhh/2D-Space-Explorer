using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuFeature : MonoBehaviour
{
    [SerializeField] GameObject pausedMenu;
    public void Pause()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
