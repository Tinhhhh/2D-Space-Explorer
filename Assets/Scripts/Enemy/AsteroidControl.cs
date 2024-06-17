using UnityEngine;
using System.Collections;

public class AsteroidControl : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask LayerMask;
    private Transform playerTransform;
    private bool isFollowing;

    private void Start()
    {
        isFollowing = false;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
