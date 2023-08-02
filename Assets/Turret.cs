using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float rotationSpeed = 20f;
    private float fireRate = 1.2f;
    private float bulletSpeed = 20f;
    private float detectionRange = 15f;
    private float turretWaitingTime = 0.1f;
    private float nextFireTime = 0f;

    public int turretHealth = 10;

    private bool isShooting = false; // Flag to track if the turret is shooting

    private void Update()
    {

        if (turretHealth <= 0)
        {
            // If the turret is destroyed, perform necessary actions (e.g., play an explosion effect, destroy the turret object)
            Destroy(gameObject);
            return;
        }

        // Calculate the distance between the turret and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Check if the player is within the turret's line of sight
            Vector2 direction = player.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                // Calculate the angle between the turret and the player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

                if (!isShooting)
                {
                    // Rotate the turret towards the player gradually
                    Quaternion desiredRotation = Quaternion.Euler(0f, 0f, angle);
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
                }

                // Shoot at the player if enough time has passed since the last shot
                if (Time.time >= nextFireTime && !isShooting)
                {
                    Quaternion originalRotation = transform.rotation;
                    // Pause the rotation for 0.5 seconds before shooting
                    StartCoroutine(PauseRotation(originalRotation, turretWaitingTime));
                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
        }
    }

    private System.Collections.IEnumerator PauseRotation(Quaternion originalRotation, float duration)
    {
        isShooting = true;
        transform.rotation = originalRotation; // Stop rotating

        yield return new WaitForSeconds(duration);

        // Create a bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add logic to give the bullet a velocity
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = bullet.transform.up * bulletSpeed;
        }

        isShooting = false;
    }

    public void TakeDamage(int damage)
    {
        turretHealth -= damage;
        // Add any additional logic for handling turret damage (e.g., play a hit effect, update UI, etc.)
    }
}