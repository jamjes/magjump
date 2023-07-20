using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] Path;
    private int _currentNodeIndex = 0;

    [SerializeField] private float _speed = 2f;
    
    private void Update()
    {
        if (Vector2.Distance(Path[_currentNodeIndex].transform.position, transform.position) < 0.1f)
        {
            _currentNodeIndex++;
            
            if (_currentNodeIndex >= Path.Length)
            {
                _currentNodeIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Path[_currentNodeIndex].transform.position, Time.deltaTime * _speed);
    }
}
