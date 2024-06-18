using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    private bool hasTriggered;
    private PlayerManager playerManager;

    private void Start()
    {
        //Lay gia tri hien tai 
        playerManager = PlayerManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            playerManager.AddMoreLife();
            Destroy(gameObject);
        }
    }
}
