using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text extralifeDisplay;
    [SerializeField] private GameObject pauseButton;
    private ScoreManager scoreManager;
    private HighestScoreManager highestScoreManager;
    private UIManager uiManager;
    public int extralife;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        scoreManager = ScoreManager.instance;
        highestScoreManager = HighestScoreManager.instance;
        uiManager = UIManager.Instance;
        this.player = GameObject.Find("Player");
        this.player.SetActive(true);
    }

    private void OnGUI()
    {
        extralifeDisplay.text = extralife.ToString();
    }

    public bool IsAlive()
    {
        if (extralife <= 0)
        {
            return false;
        }
        return true;
    }

    public void AddMoreLife()
    {
        extralife += 1;
        OnGUI();
    }

    public void MinusExtraLife()
    {
        scoreManager.ChangeCoins(500);
        extralife = extralife - 1;
        

        if (extralife <= 0)
        {
            extralife = 0;
            uiManager.Player.SetActive(false);
            uiManager.Title.SetActive(true);
            uiManager.Restart.SetActive(true);
            uiManager.Exit.SetActive(true);
            uiManager.MainMenu.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            //Sau khi chet 1 mang thi chuyen vao trang thai khong the bi tan cong
            player.GetComponent<PlayerAnimations>().ShowDeadAnimation();
            player.tag = "Untagged";
            player.layer = 0;
            StartCoroutine(ActivatePlayerAfterDelay(3f));
        }
        OnGUI();
        highestScoreManager.ResetHighestScore();
        highestScoreManager.HighestScoreUpdate(scoreManager.Getscore());



    }
    //tro lai trang thai ban dau sau 3 giay
    private IEnumerator ActivatePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.tag = "Player";
        player.layer = 6;
        player.GetComponent<PlayerAnimations>().ResetDeadAnimation();
    }
}
