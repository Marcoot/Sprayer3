using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCount;
    [SerializeField] private int totalEnemies;
    public GameObject enemyShield;
    private TMP_Text enemyCountText;

    private void Start()
    {
        enemyCountText = GameObject.FindGameObjectWithTag("CountEnemyText").GetComponent<TMP_Text>();
        UpdateEnemyCount();
    }

    private void Update()
    {
        UpdateEnemyCountText();
    }

    private void UpdateEnemyCount()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //enemyCount = enemies.Length;
        enemyCount = totalEnemies;
        UpdateEnemyCountText();
    }

    public void UpdateEnemyCountText()
    {
        enemyCountText.text = "Viruses left: " + enemyCount.ToString();
        Debug.Log(enemyCount);

        if (enemyCount == 1)
        {
            enemyShield.SetActive(false);
            Debug.Log("Doei shield");
        }
    }
}