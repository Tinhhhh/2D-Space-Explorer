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

    // Start is called before the first frame update
    void Awake()
    {

        Destroy(gameObject, bulletExist);
    }

    void Start()
    {
        playerManager = PlayerManager.instance;
        if (entity != "Player")
        {
            direction = Vector2.up;
        }
        else
        {
            direction = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
        }
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
                //Xoa doi tuong bi va cham
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
