using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMagnetismHandler : MonoBehaviour
{
    private PlayerController _player;
    [SerializeField] private LayerMask _groundLayer;
    public Platform TargetPlatform {private set; get;}

    private void Start()
    {
        _player = GetComponent<PlayerController>();
    }

    private bool MagnetismCheck()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_player.BoxCollider.bounds.center, _player.BoxCollider.bounds.size, 0f, _player.Direction, 2, _groundLayer);

        if (raycastHit.collider != null)
        {
            TargetPlatform = raycastHit.collider.GetComponent<Platform>();
        }
        else
        {
            TargetPlatform = null;
        }

        return raycastHit.collider != null;
    }
}
