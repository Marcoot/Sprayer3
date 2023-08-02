using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSize : MonoBehaviour
{
    [SerializeField] private float initialScaleSpeed = 0.5f;
    [SerializeField] private float scaleSpeedDecreaseRate = 0.1f;

    public GameObject shatteredPrefab;

    private float currentScaleSpeed;

    private void Start()
    {
        currentScaleSpeed = initialScaleSpeed;
    }

    private void Update()
    {
        transform.localScale *= (1 + currentScaleSpeed * Time.deltaTime);
        currentScaleSpeed -= scaleSpeedDecreaseRate * Time.deltaTime;
        currentScaleSpeed = Mathf.Max(currentScaleSpeed, 0f);

        if(currentScaleSpeed <= 0f)
        {
            Destroy(gameObject,1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Glass"))
        {
            Destroy(collision.gameObject);
            SoundEffects.Instance.BreakGlass();
            GameObject shatteredObject = Instantiate(shatteredPrefab, transform.position, transform.rotation);
            Destroy(shatteredObject, 0.3f);
        }
    }
}