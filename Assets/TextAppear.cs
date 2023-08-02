using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAppear : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    public float fadeSpeed = 1f;

    private int currentIndex = 0;
    private float alpha = 0f;

    private void Start()
    {
        // Set the initial alpha values of all texts to 0
        foreach (TextMeshProUGUI text in texts)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }
    }
    private void Update()
    {
        // Fade in the current text
        alpha += fadeSpeed * Time.deltaTime;

        // Clamp the alpha value between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // Set the alpha value of the current text
        texts[currentIndex].color = new Color(texts[currentIndex].color.r, texts[currentIndex].color.g, texts[currentIndex].color.b, alpha);

        // Check if the current text has reached full visibility
        if (alpha >= 1f)
        {
            // Set the alpha value of the current text to 255
            texts[currentIndex].color = new Color(texts[currentIndex].color.r, texts[currentIndex].color.g, texts[currentIndex].color.b, 1f);

            // Move to the next text
            currentIndex++;

            // Check if all texts have been displayed
            if (currentIndex >= texts.Length)
            {
                // Disable this script once all texts have been displayed
                enabled = false;
                return;
            }

            // Reset the alpha value
            alpha = 0f;

            // Set the initial alpha value of the next text to 0
            texts[currentIndex].color = new Color(texts[currentIndex].color.r, texts[currentIndex].color.g, texts[currentIndex].color.b, alpha);
        }
    }
}