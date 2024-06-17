using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject pauseButton;
    public static PlayerManager instance;
    [SerializeField] private TMP_Text extralifeDisplay;
    public int extralife = 1;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    void Update(){
        // extralife = playerExtralife.GetExtraLife();
    }

    private void OnGUI()
    {
        extralifeDisplay.text = extralife.ToString();
    }

    public int GetExtraLife()
    {
        return extralife;
    }

    
    public void MinusExtraLife(int amount)
    {
        extralife -= amount;
        if (extralife <= 0)
        {
           UIManager.Instance.Title.SetActive(true);
           UIManager.Instance.Restart.SetActive(true);
           UIManager.Instance.Exit.SetActive(true);
           UIManager.Instance.MainMenu.SetActive(true);
           pauseButton.SetActive(false);
        }
    }

    
}
