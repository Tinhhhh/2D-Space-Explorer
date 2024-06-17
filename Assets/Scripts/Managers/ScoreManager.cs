using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TMP_Text scoreDisplay;
    private PlayerManager playerManager;

    private int score;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // Bắt đầu Coroutine để tăng điểm mỗi 2 giây
        StartCoroutine(IncreaseCoinsOverTime());
        playerManager = PlayerManager.instance;
    }
    private void OnGUI()
    {
        scoreDisplay.text = score.ToString();
    }

    public void ChangeCoins(int amount)
    {
        score += amount;
        if (score <= 0)
        {
            score = 0;
        }
    }

    public int GetScore()
    {
        return score;
    }

    private IEnumerator IncreaseCoinsOverTime()
    {
        while (true && playerManager.extralife <=0)
        {
            yield return new WaitForSeconds(2f); // Chờ 2 giây
            ChangeCoins(50); // Tăng 50 điểm
        }
    }

}
