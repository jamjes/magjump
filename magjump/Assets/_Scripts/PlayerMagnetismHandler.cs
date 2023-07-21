using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetismHandler : MonoBehaviour
{
    public Vector2 Direction;
    public bool NorthField, SouthField;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Direction = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Direction = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Direction = Vector2.left;
        }
        else
        {
            Direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X))
        {
            NorthField = true;
        }
        else
        {
            NorthField = false;
        }

        if (Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z))
        {
            SouthField = true;
        }
        else
        {
            SouthField = false;
        }
    }
}
