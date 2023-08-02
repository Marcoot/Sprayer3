using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 8;
    public int currentHealth;
    public Transform respawnPoint;
    public GameObject shield;
    [SerializeField] private float limitTime = 5;
    private float invincibilityDuration = 1.5f;

    public Healthbar healthbar;
    public Collider2D playerCollider;

    private Timer timer;

    private bool isInvincible = false;
    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
        shield.SetActive(false);
        // Find the Timer object in the current scene
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        if (timerObject != null)
        {
            timer = timerObject.GetComponent<Timer>();
        }
        else
        {
            Debug.Log("Timer object not found in the current scene.");
        }
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        //+health -time
        if (Input.GetKeyDown(KeyCode.J) && !isInvincible)
        {
            Debug.Log("Time before: " + timer.currentTime);
            if(limitTime < (timer.duration - timer.currentTime) && currentHealth != maxHealth)
            {
                TakeDamage(-1);
                timer.currentTime = timer.currentTime + limitTime;
                Debug.Log("Time after: " + timer.currentTime);
            }
        }

        //-health +time
        if (Input.GetKeyDown(KeyCode.K) && !isInvincible)
        {
            Debug.Log("Time Before: " + timer.currentTime);
            if (currentHealth > 1)
            {
                TakeDamage(1);
                timer.currentTime = timer.currentTime - limitTime;
                Debug.Log("Time after: " + timer.currentTime);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the Timer object in the new scene
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        if (timerObject != null)
        {
            timer = timerObject.GetComponent<Timer>();
        }
        else
        {
            Debug.Log("Timer object not found in the current scene.");
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
            SoundEffects.Instance.PlayerHit();

            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(InvincibilityCoroutine());
            }
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        shield.SetActive(true);
        //playerCollider.enabled = false;
        yield return new WaitForSeconds(invincibilityDuration);
        //playerCollider.enabled = true; // Enable the collider
        shield.SetActive(false);
        isInvincible = false;
    }

    public void GainHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Player gained " + amount + " health.");
    }

    public void Die()
    {
        Debug.Log("Player died.");
        SceneManager.LoadScene("LoseScreen");
        //currntHealth = maxHealth;
        //healthbar.SetHealth(currentHealth);
        //transform.position = respawnPoint.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // Adjust the damage amount as needed
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            if (currentHealth <= (maxHealth - 2))
            {
                TakeDamage(-2); // Heal
                Destroy(collision.gameObject);
            }
            else if(currentHealth == (maxHealth - 1))
            {
                TakeDamage(-1);
                Destroy(collision.gameObject);
            }
            else if(currentHealth == maxHealth)
            {
                return;
            }
        }
    }
}