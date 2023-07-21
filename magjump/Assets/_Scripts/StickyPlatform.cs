using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.transform.SetParent(transform); //Allows player to move with platform
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.transform.SetParent(null); //Stops player moving with platform
        }
    }
}
