using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    //[SerializeField] private float mouseZ = 6f;
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, 5f);
    public GunController gunController;

    private void Start()
    {
        Cursor.visible = false;
        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    private void Update()
    {
        if (gunController.normalWeapon)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        }
    }
}