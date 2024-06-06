using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootCooldown = 1f;
    private float lastShootTime;

    // Start is called before the first frame update
    void Start()
    {
        lastShootTime = -shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= lastShootTime + shootCooldown)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            lastShootTime = Time.time;

        }

    }
}
