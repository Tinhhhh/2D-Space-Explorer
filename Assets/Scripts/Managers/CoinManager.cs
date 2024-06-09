using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    [SerializeField] private TMP_Text coinsDisplay;

    private int coins;
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
    }
    private void OnGUI()
    {
        coinsDisplay.text = coins.ToString();
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
        if (coins <= 0)
        {
            coins = 0;
        }
    }

    private IEnumerator IncreaseCoinsOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // Chờ 2 giây
            ChangeCoins(50); // Tăng 50 điểm
        }
    }

}
