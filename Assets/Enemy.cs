using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject sprayEffect;
    public Vector3 effectPositionOffset;
    public EnemyCounter enemyCounter;
    public EnemyType enemyType; // Enemy's type (Stationary or Following)
    public float moveSpeed = 2f; // Speed of the following enemy
    public float detectionRange = 5f; // Range within which the enemy will start following the player
    public LayerMask obstacleMask;

    private int health = 3; // Enemy's initial health
    private Transform player; // Reference to the player's transform
    //private bool isFollowing = false; // Flag to track if the enemy is currently following the player
   // private Pathfinding pathfinding;
    private List<Vector2> path;
    //private int currentWaypoint = 0;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
        //pathfinding = GetComponent<Pathfinding>();
        path = new List<Vector2>();
    }

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
        GameObject Deadeffect = Instantiate(sprayEffect, transform.position + effectPositionOffset, Quaternion.identity);
        Destroy(Deadeffect,2f);

        if (gameObject.name == "Boss")
        {
            SoundEffects.Instance.BossDies();
        }

        enemyCounter.enemyCount--;
        enemyCounter.UpdateEnemyCountText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }
    /*private void Update()
    {
        //if (enemyType == EnemyType.Following && pathfinding != null && player != null)
        {
            // Find path to the player using A* algorithm
            path = pathfinding.FindPath(transform.position, player.position);

            if (path != null && path.Count > 0)
            {
                // Move towards the current waypoint
                Vector2 direction = (path[currentWaypoint] - (Vector2)transform.position).normalized;
                Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;

                // Check for obstacles
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, moveSpeed * Time.deltaTime, obstacleMask);
                if (hit.collider == null)
                {
                    // No obstacles, move to the new position
                    transform.position = newPosition;
                }
                else
                {
                    // Obstacle detected, calculate a new path to avoid it
                    path = pathfinding.FindPath(transform.position, player.position);
                    currentWaypoint = 0;
                }

                // Calculate the angle to rotate towards the player
                Vector2 lookDirection = player.position - transform.position;
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

                // Apply rotation to face the player
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                // Check if reached the current waypoint
                float distance = Vector2.Distance(transform.position, path[currentWaypoint]);
                if (distance < 0.1f)
                {
                    // Move to the next waypoint
                    currentWaypoint++;
                    if (currentWaypoint >= path.Count)
                    {
                        // Reached the player, do something (e.g., attack)
                        currentWaypoint = 0;
                    }
                }
            }
        }
    }*/
}