using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int value;
    private PlayerManager playerManager;

    private void Start()
    {
        //Lay gia tri hien tai 
        playerManager = PlayerManager.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Enemy")
        // {
        //     GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //     Destroy(explosion, 2f);
        //     Destroy(collision.gameObject);
        //     gameObject.GetComponent<PlayerAnimations>().ShowDeadAnimation();
        //     playerManager.MinusExtraLife();
        // }
    }

}



