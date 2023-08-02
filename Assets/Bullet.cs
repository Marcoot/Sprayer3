using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public GameObject sprayEffect;
    public GameObject owner;
    private Turret2 turret;
    private EnemyNew enemy;

    private void Start()
    {
        turret = FindObjectOfType<Turret2>();
        enemy = FindObjectOfType<EnemyNew>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject explosionEffect = Instantiate(sprayEffect, transform.position, Quaternion.identity);

        if (collision.gameObject.CompareTag("Walls") && owner.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SoundEffects.Instance.TurretExplosion();
        }

        if (collision.gameObject.CompareTag("Walls") && owner.CompareTag("Player"))
        {
            Destroy(gameObject);
            SoundEffects.Instance.PlayerExplosion();
        }

        if (collision.gameObject.CompareTag("Player") && owner.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy hit player");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Destroy(gameObject);
            }
            SoundEffects.Instance.TurretExplosion();
        }

        if (collision.gameObject.CompareTag("Shield") && owner.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Shield") && owner.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject); // Destroy the collided bullet
            //Destroy(gameObject); // Destroy the current bullet
            SoundEffects.Instance.TurretExplosion();
        }

        if (collision.gameObject.CompareTag("Shockwave") && owner.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SoundEffects.Instance.TurretExplosion();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SoundEffects.Instance.PlayerExplosion();
        }

        if (collision.gameObject.CompareTag("Enemy") && owner.CompareTag("Player"))
        {
            Turret2 turret = collision.gameObject.GetComponent<Turret2>();
            if (turret != null)
            {
                turret.TakeDamage(1);
            }
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            SoundEffects.Instance.PlayerExplosion();
            Destroy(this.gameObject);
            //Debug.Log("current health of the turret is: " + turret.currentHealth + " From" + turret.name);
        }

        if (collision.gameObject.CompareTag("Glass"))
        {
            Destroy(gameObject);
        }

        Destroy(explosionEffect, 2f);
    }
}