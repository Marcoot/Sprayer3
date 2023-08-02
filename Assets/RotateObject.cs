using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the object around the z-axis at a constant speed
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
