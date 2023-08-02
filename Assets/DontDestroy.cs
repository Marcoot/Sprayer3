using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] objectsToPersist;

    public GameObject playerObject;
    public GameObject managerObject;
    public Camera mainCamera;
    public GameObject canvasUI;
    public GameObject HackerBackground;
    public GameObject soundEffects;
    public GameObject Crosshair;

    private void Awake()
    {
        MarkObjectsForPersistence();
    }

    private void MarkObjectsForPersistence()
    {
        foreach (GameObject obj in objectsToPersist)
        {
            DontDestroyOnLoad(obj);
        }

        if (playerObject != null)
        {
            DontDestroyOnLoad(playerObject);
        }

        /*if (managerObject != null)
        {
            DontDestroyOnLoad(managerObject);
        }*/

        if (soundEffects != null)
        {
            DontDestroyOnLoad(soundEffects);
        }

        if (Crosshair != null)
        {
            DontDestroyOnLoad(Crosshair);
        }

        if (mainCamera != null)
        {
            DontDestroyOnLoad(mainCamera.gameObject);
        }

        if (canvasUI != null)
        {
            DontDestroyOnLoad(canvasUI);
        }

        if(HackerBackground != null)
        {
            DontDestroyOnLoad(HackerBackground);
        }
    }
}
