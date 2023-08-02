using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUnlock : MonoBehaviour
{
    private GunController gunController;
    private Gate gate;

    private void Start()
    {
        gate = GameObject.FindGameObjectWithTag("Gate").GetComponent<Gate>();
        gunController = GameObject.FindGameObjectWithTag("Guns").GetComponent<GunController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gate.ToggleGateActiveStatus();
            if (gunController.normalWeapon) gunController.shockTool = true;
            else gunController.normalWeapon = true;
        }
    }
}
