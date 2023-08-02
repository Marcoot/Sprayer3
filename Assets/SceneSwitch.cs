using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            GoToLevel("Level1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GoToLevel("Level2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GoToLevel("Level3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GoToLevel("LoseScreen");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GoToLevel("WinScreen");
        }
    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        Debug.Log("lekker naar level: " + levelName);
    }
}
