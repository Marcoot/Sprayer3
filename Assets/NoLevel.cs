using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLevel : MonoBehaviour
{
    [SerializeField] private string[] tagsToDestroy = { "Player", "MainCamera", "Background", "Sounds", "Canvas", "Crosshair" };
    public bool sceneRunning = true;


    private void Update()
    {
        if (sceneRunning)
        {
            foreach (string tag in tagsToDestroy)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject obj in objects)
                {
                    Destroy(obj);
                }
            }
            sceneRunning = false;
        }
    }
}
