using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private string entity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float bulletExist;
    [SerializeField] private GameObject explosionPrefab;
    private PlayerManager playerManager;
    private Vector2 direction;
    private ScoreManager scoreManager;

    // Start is called before the first frame update

    void Start()
    {
        if (entity != "Player")
        {
            direction = Vector2.up;
        }
        else
        {
            direction = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
        }
        scoreManager = ScoreManager.instance;
        playerManager = PlayerManager.instance;
        Destroy(gameObject, bulletExist);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(entity))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);

            if (collision.gameObject.CompareTag("Player"))
            {
                playerManager.MinusExtraLife();
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                scoreManager.ChangeCoins(200);
                //Xoa doi tuong bi va cham
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
