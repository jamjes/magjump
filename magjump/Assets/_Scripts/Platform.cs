using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomVars;

public class Platform : MonoBehaviour
{
    [SerializeField] private Polarity _charge;

    private void Start()
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        if (_charge == Polarity.North) spr.color = Color.red;
        else if (_charge == Polarity.South) spr.color = Color.blue;
        else spr.color = Color.white;
    }

    public Polarity ReturnPolarity()
    {
        return _charge;
    }
}
