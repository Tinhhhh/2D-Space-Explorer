using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuFeature : MonoBehaviour
{
    public void StartNewGame()
    {
        var highestScore = PlayerPrefs.GetInt("HighestScore"); 
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("HighestScore", highestScore);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
