using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 mousePosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("North Pole");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("South Pole");
        }

        currentPosition = transform.position;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
