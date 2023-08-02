using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;
    public AudioSource soundEffectSource;
    public AudioClip turretDies, turretFires, turretsLoad, turretExplosion,
        playerShoot, playerHit, playerDies, playerExplosion, playerWave,
        enemySpawns, enemyWandering,
        unlockDoor, lockedDoor, breakGlass,
        bossDies;
    public GameObject cameraObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        transform.position = cameraObject.transform.position;
    }

    //Environment
    public void LockedDoor()
    {
        soundEffectSource.PlayOneShot(lockedDoor, 1f);
    }

    public void UnlockDoor()
    {
        soundEffectSource.PlayOneShot(unlockDoor, 1f);
    }

    public void BreakGlass()
    {
        soundEffectSource.PlayOneShot(breakGlass, 1f);
    }

    //player
    public void PlayerShoot()
    {
        soundEffectSource.PlayOneShot(playerShoot, 1f);
    }

    public void PlayerExplosion()
    {
        soundEffectSource.PlayOneShot(playerExplosion, 1f);
    }

    public void PlayerWave()
    {
        soundEffectSource.PlayOneShot(playerWave, 1f);
    }

    public void PlayerHit()
    {
        soundEffectSource.PlayOneShot(playerHit, 1f);
    }

    //enemies
    public void TurretShoot()
    {
        soundEffectSource.PlayOneShot(turretFires, 0.1f);
    }

    public void TurretExplosion()
    {
        soundEffectSource.PlayOneShot(turretExplosion, 0.25f);
    }

    public void TurretDies()
    {
        soundEffectSource.PlayOneShot(turretDies, 1f);
    }

    public void BossDies()
    {
        soundEffectSource.PlayOneShot(bossDies, 1f);
    }
}
