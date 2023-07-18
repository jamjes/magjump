using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomVars;

public class Magnetise : MonoBehaviour
{
    [SerializeField] private Polarity _charge; //Reference to which polarity this object is.
    public bool EnableDebugMode = false;

    private void Start()
    {
        if (EnableDebugMode)
        {
            SpriteRenderer spr = GetComponent<SpriteRenderer>();

            if (_charge == Polarity.North) spr.color = Color.red;
            else spr.color = Color.blue;
        }
    }
}
