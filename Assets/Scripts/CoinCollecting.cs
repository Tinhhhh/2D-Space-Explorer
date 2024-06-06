using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;
    private CoinManager1 coinManager;

    private void Start()
    {
        //Lay gia tri hien tai 
        coinManager = CoinManager1.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            coinManager.ChangeCoins(value);
            Destroy(gameObject);
        }
    }
}
