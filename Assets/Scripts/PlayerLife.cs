using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerManager1 playerManager;

    private void Start()
    {
        playerManager = PlayerManager1.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
            gameObject.GetComponent<PlayerAnimations>()
                          .ShowDeadAnimation();
            playerManager.MinusExtraLife(1);
            if (playerManager.extralife <= 0)
            {
                StartCoroutine(DelayedPlayerDead(0.18f, gameObject));
            }
        }
    }

    private IEnumerator DelayedPlayerDead(float delay, GameObject gameObject)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}



