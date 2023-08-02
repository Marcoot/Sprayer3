using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterGlass : MonoBehaviour
{
    public GameObject shatteredPrefab;
    public float prefabDestroyDelay = 0.5f;
    public float alphaFadeDuration = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shockwave"))
        {
            Destroy(gameObject);
            // Spawn the shattered prefab at the same position and rotation as the object
            //GameObject shatteredObject = Instantiate(shatteredPrefab, transform.position, transform.rotation);

            // Start a coroutine to fade the alpha color of the prefab to zero over time
            //StartCoroutine(FadeAlphaToZero(shatteredObject.GetComponent<SpriteRenderer>(), alphaFadeDuration));

            // Destroy the object immediately

            // Destroy the spawned prefab after the specified delay
            //Destroy(shatteredObject, prefabDestroyDelay);
        }
    }

    /*private System.Collections.IEnumerator FadeAlphaToZero(SpriteRenderer renderer, float duration)
    {
        Color color = renderer.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            color.a = Mathf.Lerp(startAlpha, 0f, t);
            renderer.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 0f;
        renderer.color = color;
    }*/
}
