using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollecting : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;
    private ScoreManager scoreManager;

    private void Start()
    {
        //Lay gia tri hien tai 
        scoreManager = ScoreManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            scoreManager.ChangeCoins(value);
            Destroy(gameObject);
        }
    }
}
