using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public string playerTag = "Player";  // Tag of the player object

    private Transform playerTransform;  // Reference to the player's transform

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        playerTransform = playerObject.transform;
        //Debug.Log("StartPosition: " + playerTransform.position);
    }

    private void Update()
    {
        transform.position = playerTransform.position;
        //Debug.Log("Current position: " + playerTransform.position);
    }
}