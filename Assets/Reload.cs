using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxBullets(int bullets)
    {
        slider.maxValue = bullets;
        slider.value = bullets;

        gradient.Evaluate(1f);
    }

    public void SetNumberBullets(int bullets)
    {
        slider.value = bullets;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
