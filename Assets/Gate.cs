using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            //ToggleGateActiveStatus();
        }
    }

    public void ToggleGateActiveStatus()
    {
        foreach (Transform child in transform)
        {
            GameObject gateObject = child.gameObject;
            gateObject.SetActive(!gateObject.activeSelf);
        }
    }
}
