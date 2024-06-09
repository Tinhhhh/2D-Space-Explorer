using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask LayerMask;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private string tagName;
    [SerializeField] private int value;
    private CoinManager coinManager;

    private Transform playerTransform;
    private bool isFollowing;

    private void Start()
    {
        isFollowing = false;
        coinManager = CoinManager.instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isFollowing && Detect())
        {
            StartCoroutine(FollowPlayerForDuration(3f)); // Đuổi theo player trong 3 giây
        }
    }

    private bool Detect()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(gameObject.transform.position, range, LayerMask);
        // Check if there is a collision => playerCollider != null else null.
        if (playerCollider != null)
        {
            playerTransform = playerCollider.transform;
            return true;
        }
        playerTransform = null;
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
            coinManager.ChangeCoins(value);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
