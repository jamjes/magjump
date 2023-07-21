using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] Path;
    private int _currentNodeIndex = 0;

    [SerializeField] private float _speed = 6f;
    
    private void Update()
    {
        //If platform has reached target position
        if (Vector2.Distance(Path[_currentNodeIndex].transform.position, transform.position) < 0.1f)
        {
            //Increment target position index
            _currentNodeIndex++;
            
            //If current index is more than the last index
            if (_currentNodeIndex >= Path.Length)
            {
                _currentNodeIndex = 0;
            }
        }

        //Move towards position by speed value
        transform.position = Vector2.MoveTowards(transform.position, Path[_currentNodeIndex].transform.position, Time.deltaTime * _speed);
    }
}
