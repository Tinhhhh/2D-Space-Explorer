using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager1 : MonoBehaviour
{
   public static CoinManager1 instance;
   [SerializeField] private TMP_Text coinsDisplay;

   private int coins;
   private void Awake(){
    if (!instance)
    {
        instance = this;
    }
   }

   private void OnGUI()
    {
        coinsDisplay.text = coins.ToString();
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
    }

}
