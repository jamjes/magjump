using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private PlayerMagnetismHandler _player;
    [SerializeField] private Sprite _idle;
    [SerializeField] private Sprite _upPending;
    [SerializeField] private Sprite _upNorth;
    [SerializeField] private Sprite _upSouth;
    [SerializeField] private Sprite _rightPending;
    [SerializeField] private Sprite _rightNorth;
    [SerializeField] private Sprite _rightSouth;
    [SerializeField] private Sprite _downPending;
    [SerializeField] private Sprite _downNorth;
    [SerializeField] private Sprite _downSouth;
    [SerializeField] private Sprite _leftPending;
    [SerializeField] private Sprite _leftNorth;
    [SerializeField] private Sprite _leftSouth;

    private void Start()
    {
        _player = GetComponent<PlayerController>().MagnetismHandler;
    }

    private void Update()
    {
        /*switch()
        {
            case Vector2 v when v.Equals(Vector2.zero):
                if (_spriteRenderer.sprite != _idle) _spriteRenderer.sprite = _idle;
                break;
            
            case Vector2 v when v.Equals(Vector2.up):
                //if (_player.NorthField) _spriteRenderer.sprite = _upNorth;
                //else if (_player.SouthField) _spriteRenderer.sprite = _upSouth;
                //else if (_spriteRenderer.sprite != _upPending) _spriteRenderer.sprite = _upPending;
                break;

            case Vector2 v when v.Equals(Vector2.right):
                //if (_player.NorthField) _spriteRenderer.sprite = _rightNorth;
                //else if (_player.SouthField) _spriteRenderer.sprite = _rightSouth;
                //else if (_spriteRenderer.sprite != _rightPending) _spriteRenderer.sprite = _rightPending;
                break;

            case Vector2 v when v.Equals(Vector2.down):
                //if (_player.NorthField) _spriteRenderer.sprite = _downNorth;
                //else if (_player.SouthField) _spriteRenderer.sprite = _downSouth;
                //else if (_spriteRenderer.sprite != _downPending) _spriteRenderer.sprite = _downPending;
                break;

            case Vector2 v when v.Equals(Vector2.left):
                //if (_player.NorthField) _spriteRenderer.sprite = _leftNorth;
                //else if (_player.SouthField) _spriteRenderer.sprite = _leftSouth;
                //if (_spriteRenderer.sprite != _leftPending) _spriteRenderer.sprite = _leftPending;
                break;
            
        }*/
    }
}
