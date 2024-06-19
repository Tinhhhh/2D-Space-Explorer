using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text extralifeDisplay;
    [SerializeField] private GameObject pauseButton;
    public static PlayerManager instance;
    private ScoreManager scoreManager;
    private HighestScoreManager highestScoreManager;
    private UIManager uiManager;
    public int extralife;

    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // if not, set instance to this
            instance = this;
            // Don't destroy this instance when loading a new scene
        }
        else if (instance != this)
        {
            // If instance already exists and it's not this, then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a PlayerManager.
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("ExtraLife"))
        {
            extralife = PlayerPrefs.GetInt("ExtraLife");
            CanBeAttacked();

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

    public int GetExtraLife()
    {
        return extralife;
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
        extralife = extralife - 1;

        if (extralife <= 0)
        {
            extralife = 0;
            uiManager.Player.SetActive(false);
            uiManager.GameOverTitle.SetActive(true);
            uiManager.Restart.SetActive(true);
            uiManager.Exit.SetActive(true);
            uiManager.MainMenu.SetActive(true);
            pauseButton.SetActive(false);
            highestScoreManager.HighestScoreUpdate();
            // highestScoreManager.ResetHighestScore();

        }
        else
        {
            //Sau khi chet 1 mang thi chuyen vao trang thai khong the bi tan cong
            CanBeAttacked();

        }
    }

    private void CanBeAttacked()
    {
        StartCoroutine(InactivatePlayerAfterDelay(0));
        StartCoroutine(ActivatePlayerAfterDelay(3f));
    }

    private IEnumerator InactivatePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<PlayerAnimations>().ShowDeadAnimation();
        player.tag = "Untagged";
        player.layer = 0;
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
