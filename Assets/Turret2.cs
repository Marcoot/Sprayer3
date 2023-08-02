using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public EnemyCounter enemyCounter;
    public Transform gunPoint;
    public float rotationSpeed = 100f;
    public float shootingInterval = 3f;
    public float bulletForce = 20f;
    public float waitTime = 0.5f;
    public int maxHealth = 8;
    [SerializeField] private float activationDistance = 12f;

    public int currentHealth;
    private float timeSinceLastShot = 0f;
    private bool isWaiting = false;

    void Start()
    {
        currentHealth = maxHealth;
    }   

    void Update()
    {
        // Calculate the distance between the turret and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the turret is within the activation distance
        if (distanceToPlayer > activationDistance)
        {
            return; // Exit the Update method if the turret is too far from the player
        }

        if (isWaiting)
        {
            return;
        }

        // Rotate the turret to look at the player
        Vector3 targetDirection = player.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Shoot bullets
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
            StartCoroutine(WaitBeforeNextShot());
        }
    }

    IEnumerator WaitBeforeNextShot()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }

    void Shoot()
    {
        // Instantiate a bullet at the gunPoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position + new Vector3(0, 0, 0.1f), gunPoint.rotation); ;

        // Add a force to the bullet in the forward direction
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        SoundEffects.Instance.TurretShoot();
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log("Destroying turret: " + gameObject.name);
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject); // Destroy the turret when health reaches 0
            enemyCounter.enemyCount--;
            enemyCounter.UpdateEnemyCountText();
            SoundEffects.Instance.TurretDies();
        }
    }
}