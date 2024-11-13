using System.Collections;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float bulletSpeed = 5f;
    public float detectionRange = 10f;
    public float stopShootingRadius = 3f;

    private Transform player;
    private float timeSinceLastShot;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    private void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            if (Vector2.Distance(transform.position, player.position) > stopShootingRadius)
            {
                timeSinceLastShot += Time.deltaTime;
                if (timeSinceLastShot >= shootInterval)
                {
                    Shoot();
                    timeSinceLastShot = 0f;
                }
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Vector2 direction = (player.position - firePoint.position);
        direction.y += 0.33f;
        direction = direction.normalized;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;
    }
}


