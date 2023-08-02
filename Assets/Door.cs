using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public EnemyCounter enemyCounter;

    void Update()
    {
        if(enemyCounter.enemyCount == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundEffects.Instance.LockedDoor();
        }
    }
}
