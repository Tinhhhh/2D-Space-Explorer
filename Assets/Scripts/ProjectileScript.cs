using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float bulletExist;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int value;
    private CoinManager coinManager;


    // Start is called before the first frame update
    void Awake()
    {

        Destroy(gameObject, bulletExist);
    }

    void Start()
    {
        coinManager = CoinManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            coinManager.ChangeCoins(value);
            Destroy(explosion, 2f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
