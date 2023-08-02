using UnityEngine;
using System.Collections;
using System.IO;

public enum EnemyType
{
    Stationary,
    Following
}

public class EnemyNew : MonoBehaviour
{
    public EnemyCounter enemyCounter;
    public GameObject sprayEffect;
    public Transform player;
    public float followDistance = 5f;
    private int health = 3;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Decrease the enemy's health by the damage amount

        if (health <= 0)
        {
            Die(); // Call the Die method if the enemy's health reaches or falls below zero
        }
    }

    private void Die()
    {
        // Remove the enemy from the scene
        Destroy(gameObject);
        GameObject Deadeffect = Instantiate(sprayEffect, transform.position, Quaternion.identity);
        Destroy(Deadeffect, 2f);

        enemyCounter.enemyCount--;
        enemyCounter.UpdateEnemyCountText();
    }
}