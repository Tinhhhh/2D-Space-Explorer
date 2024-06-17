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

    
    public void MinusExtraLife(int amount)
    {
        extralife -= amount;
        if (extralife <= 0)
        {
           UIManager.Instance.Title.SetActive(true);
           UIManager.Instance.Restart.SetActive(true);
           UIManager.Instance.Exit.SetActive(true);
           UIManager.Instance.MainMenu.SetActive(true);

            //Pause Button Disappear When Game Over Appear
           pauseButton.SetActive(false);
        }

        /*if (Winning Condition)
        {
            UIManager.Instance.WinningTitle.SetActive(true);
            UIManager.Instance.WinningExit.SetActive(true);
            UIManager.Instance.WinningStartGame.SetActive(true);
            UIManager.Instance.WinningMainMenu.SetActive(true);

            //Pause Button Disappear When Winning Appear
            pauseButton.SetActive(false);
        }*/
    }


}
