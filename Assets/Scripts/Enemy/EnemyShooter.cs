using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyShooter : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootCooldown = 2f;
    [SerializeField] private float projectileLifetime = 2f; // new parameter
    private float lastShootTime;

    private Transform playerTransform;
    private bool isPlayerInRange;

    void Start()
    {
        lastShootTime = -shootCooldown;
        isPlayerInRange = false;
    }

    void Update()
    {
        DetectPlayer();
        if (isPlayerInRange && Time.time >= lastShootTime + shootCooldown)
        {
            StartCoroutine(Shoot());
            lastShootTime = Time.time;
        }
    }

    private void DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(gameObject.transform.position, range, playerLayer);
        if (playerCollider != null)
        {
            playerTransform = playerCollider.transform;
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 2;
            Destroy(projectile, 3f); // destroy the projectile after 3 seconds

            yield return new WaitForSeconds(2f); // wait for 2 seconds before creating the next projectile
        }
    }
}