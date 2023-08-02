using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shockWavePrefab;
    public PlayerMovement playerMovement;
    public Reload bulletReload;
    public Reload shockWaveReload;
    public Transform bulletGunpoint;
    public Transform shockWaveGunpoint;
    [SerializeField] private float bulletForce = 25f;
    //[SerializeField] private float shockWaveForce = 10f;
    [SerializeField] private Color[] bulletColors = { Color.red, new Color(1f, 0.5f, 0f), Color.yellow, Color.green, Color.blue, new Color(0.3f, 0f, 0.5f), Color.magenta };
    private int currentColorIndex = 0;
    private int bulletShotsFired = 0;
    private int shockWaveShotsFired = 0;
    private int totalBullets = 5;
    private int totalShockWaves = 1;
    private bool bulletReloading;
    private bool shockWaveReloading;
    public GameObject normalGun;
    public bool normalWeapon;
    public bool shockTool;

    private const int maxShots = 5;
    private const int maxShockWaves = 1;
    [SerializeField] private const float bulletReloadTime = 2f;
    [SerializeField] private const float shockWaveReloadTime = 7f;

    public GameObject normalWeaponLock;
    public GameObject shocktoolLock;

    private void Update()
    {
        if (normalWeapon)
        {
            Destroy(normalWeaponLock);
            normalGun.SetActive(true);
            if (!bulletReloading && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")))
            {
                FireBullet();
            }
        }
        if (shockTool)
        {
            Destroy(shocktoolLock);
            if (!shockWaveReloading && Input.GetButtonDown("Fire2"))
            {
                FireShockWave();
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletGunpoint.position, bulletGunpoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletGunpoint.up * bulletForce, ForceMode2D.Impulse);

        Color currentColor = bulletColors[currentColorIndex];

        SpriteRenderer bulletRenderer = bullet.GetComponent<SpriteRenderer>();
        if (bulletRenderer != null)
        {
            bulletRenderer.color = currentColor;
        }

        currentColorIndex = (currentColorIndex + 1) % bulletColors.Length;

        bulletShotsFired++;
        bulletReload.SetNumberBullets(totalBullets - bulletShotsFired);
        SoundEffects.Instance.PlayerShoot();

        if (bulletShotsFired >= maxShots)
        {
            StartCoroutine(BulletReload());
            return;
        }
    }

    private void FireShockWave()
    {

        GameObject shockWave = Instantiate(shockWavePrefab, shockWaveGunpoint.position, shockWaveGunpoint.rotation);
        shockWave.transform.SetParent(transform); // Set shockwave as a child of GunController
        shockWave.SetActive(true);
        //Destroy(shockWave, 3f);

        shockWaveShotsFired++;
        shockWaveReload.SetNumberBullets(totalShockWaves - shockWaveShotsFired);
        SoundEffects.Instance.PlayerWave();

        if (shockWaveShotsFired >= maxShockWaves)
        {
            StartCoroutine(ShockWaveReload());
            return;
        }
    }

    private IEnumerator BulletReload()
    {
        bulletReloading = true;
        bulletReload.SetMaxBullets(totalBullets);

        float reloadTimer = 0f;

        Color startColor = bulletReload.gradient.Evaluate(0f);
        Color targetColor = bulletReload.gradient.Evaluate(1f);

        while (reloadTimer < bulletReloadTime)
        {
            float fillAmount = Mathf.Lerp(0f, 1f, reloadTimer / bulletReloadTime);
            bulletReload.slider.value = Mathf.Lerp(0f, totalBullets, fillAmount);
            bulletReload.fill.color = Color.Lerp(startColor, targetColor, fillAmount);

            reloadTimer += Time.deltaTime;
            yield return null;
        }

        bulletShotsFired = 0;
        bulletReloading = false;
        bulletReload.SetNumberBullets(totalBullets);
        bulletReload.fill.color = targetColor;
        bulletReload.slider.value = totalBullets;
    }

    private IEnumerator ShockWaveReload()
    {
        shockWaveReloading = true;
        shockWaveReload.SetMaxBullets(totalShockWaves);

        float reloadTimer = 0f;

        Color startColor = shockWaveReload.gradient.Evaluate(0f);
        Color targetColor = shockWaveReload.gradient.Evaluate(1f);

        while (reloadTimer < shockWaveReloadTime)
        {
            float fillAmount = Mathf.Lerp(0f, 1f, reloadTimer / shockWaveReloadTime);
            shockWaveReload.slider.value = Mathf.Lerp(0f, totalShockWaves, fillAmount);
            shockWaveReload.fill.color = Color.Lerp(startColor, targetColor, fillAmount);

            reloadTimer += Time.deltaTime;
            yield return null;
        }

        shockWaveShotsFired = 0;
        shockWaveReloading = false;
        shockWaveReload.SetNumberBullets(totalShockWaves);
        shockWaveReload.fill.color = targetColor;
        shockWaveReload.slider.value = totalShockWaves;
    }
}