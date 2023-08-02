using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedBackground : MonoBehaviour
{
    public Sprite[] frames;
    public float frameRate = 0.1f;

    private Image image;
    private int currentFrameIndex = 0;
    private float timer = 0f;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            currentFrameIndex = (currentFrameIndex + 1) % frames.Length;
            image.sprite = frames[currentFrameIndex];
            timer = 0f;
        }
    }
}