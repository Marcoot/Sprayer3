using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pathfinding;

public class Timer : MonoBehaviour
{
    [SerializeField] public float duration = 60f; 
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Color endColor = Color.red;

    public float currentTime = 0f;
    public bool isRunning;
    public bool timerDestroyed;
    private PlayerHealth health;
    public EnemyCounter enemyCount;

    private void Start()
    {
        currentTime = 0f;
        isRunning = true;
        timerText.text = "Time: " + duration.ToString("0:00");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (enemyCount.enemyCount == 0) isRunning = false;

        if (isRunning)
        {
            //Debug.Log(timerText.text);
            currentTime += Time.deltaTime;
            if (currentTime >= duration)
            {
                isRunning = false;
                health.Die();
                Debug.Log("Timer completed!");
            }

            float progress = currentTime / duration;
            timerText.text = "Time: " + (duration - currentTime).ToString("0.00");
            timerText.color = Color.Lerp(new Color(1f, 0.5f, 0f), endColor, progress);
        }
        if(!isRunning)
        {
            Destroy(gameObject,3f);
            isRunning = true;   
        }
    }
}