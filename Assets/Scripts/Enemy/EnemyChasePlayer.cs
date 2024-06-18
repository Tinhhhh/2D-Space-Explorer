using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
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

    private void Start()
    {
        isFollowing = false;
        scoreManager = ScoreManager.instance;
        playerManager = PlayerManager.instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (Detect())
        {
            StartCoroutine(FollowPlayerForDuration(3f)); // Đuổi theo player trong 3 giây
        }
    }

    private bool Detect()
    {
        if (!isFollowing)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(gameObject.transform.position, range, LayerMask);
            // Check if there is a collision => playerCollider != null else null.
            if (playerCollider != null)
            {
                playerTransform = playerCollider.transform;
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
                // Logic để di chuyển theo player
                // Ví dụ:
                Vector2 direction = (playerTransform.position - transform.position).normalized;
                transform.Translate(direction * Time.deltaTime * speed); // Giả sử tốc độ là 2
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
