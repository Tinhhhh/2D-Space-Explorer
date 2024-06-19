using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private ScoreManager Score;
    private int extralife;
    private float PlayerX;
    private float PlayerY;
    private float PlayerZ;

    public void Save()
    {
        extralife = PlayerManager.instance.GetExtraLife();
        Score = ScoreManager.instance;
        PlayerX = player.transform.position.x;
        PlayerY = player.transform.position.y;
        PlayerZ = player.transform.position.z;

        PlayerPrefs.SetInt("ExtraLife", extralife);
        PlayerPrefs.SetInt("Score", Score.score);
        PlayerPrefs.SetFloat("PlayerX", PlayerX);
        PlayerPrefs.SetFloat("PlayerY", PlayerY);
        PlayerPrefs.SetFloat("PlayerZ", PlayerZ);

        Debug.Log("Game Saved");
        Debug.Log("ExtraLife: " + extralife);
        Debug.Log("Score: " + Score.score);
        Debug.Log("PlayerX: " + PlayerX);
        Debug.Log("PlayerY: " + PlayerY);
        Debug.Log("PlayerZ: " + PlayerZ);

    }

    // Update is called once per frame
    public void Load()
    {
        SceneManager.LoadScene(1);
    }
}
