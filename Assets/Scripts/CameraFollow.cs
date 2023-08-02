using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }
    private void LateUpdate()
    {
        Vector3 playerPosition = player.position;
        Vector3 cameraPosition = transform.position;

        cameraPosition.x = playerPosition.x;
        cameraPosition.y = playerPosition.y;

        transform.position = cameraPosition;
    }
}