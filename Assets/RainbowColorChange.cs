using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowColorChange : MonoBehaviour
{
    public float speed = 1f; // Speed of color change

    private float hue; // Current hue value
    private Material material; // Reference to the object's material

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    private void Update()
    {
        // Increment the hue value based on time
        hue += Time.deltaTime * speed;

        // Wrap the hue value within the range of 0 to 1
        if (hue > 1f)
        {
            hue -= 1f;
        }

        // Set the object's material color to the current hue value
        Color newColor = Color.HSVToRGB(hue, 1f, 1f);
        material.color = newColor;
    }
}