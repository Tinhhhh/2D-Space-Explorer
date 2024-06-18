using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
public class AsteroidChasePlayer : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask LayerMask;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private string tagName;
    [SerializeField] private int value;
    private ScoreManager scoreManager;
    private PlayerManager playerManager;
    private Transform playerTransform;
    private bool isFollowing;
    private Vector2 initialDirection;

    private void Start()
    {
        isFollowing = false;
        scoreManager = ScoreManager.instance;
        playerManager = PlayerManager.instance;
    }

    void Update()
    {
        if (Detect())
        {
            StartCoroutine(FollowPlayerForDuration(4f)); // Follow player for 4 seconds
        }
    }

    private bool Detect()
    {
        if (!isFollowing)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(gameObject.transform.position, range, LayerMask);
            if (playerCollider != null)
            {
                playerTransform = playerCollider.transform;
                initialDirection = (playerTransform.position - transform.position).normalized;
                return true;
            }
        }
        return false;
    }

    private IEnumerator FollowPlayerForDuration(float duration)
    {
        isFollowing = true;
        float timer = 0f;

        while (timer < duration)
        {
            if (playerTransform != null)
            {
                transform.Translate(initialDirection * Time.deltaTime * speed);
            }
            timer += Time.deltaTime;
            yield return null;
        }

        isFollowing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            scoreManager.ChangeCoins(value);
            //Tao ra mot vu no
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);

            //Xoa doi tuong bi va cham
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
             //Tao ra mot vu no
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);

            //Tu xoa ban than
            Destroy(gameObject);
            playerManager.MinusExtraLife();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}