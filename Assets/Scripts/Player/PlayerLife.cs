using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int value;
    private PlayerManager playerManager;
    private ScoreManager scoreManager;
    private Player player;



    private void Start()
    {
        //Lay gia tri hien tai 
        scoreManager = ScoreManager.instance;
        playerManager = PlayerManager.instance;
        player = Player.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Enemy")
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(collision.gameObject);
            scoreManager.ChangeCoins(value);
            gameObject.GetComponent<PlayerAnimations>().ShowDeadAnimation();
            // gameObject.SetActive(false);
            playerManager.MinusExtraLife(1);
            if (playerManager.extralife <= 0)
            {
                Destroy(gameObject);
            }
            // else
            // {
            //     Player.instance.EnablePlayerAfterDelay(gameObject, 2f);
            // }
        }
    }


}



