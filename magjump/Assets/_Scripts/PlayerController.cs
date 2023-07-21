using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomVars;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Componants")]
    [SerializeField] private Rigidbody2D _rigidBody;    
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private BoxCollider2D _boxCollider;

    [Header("Physics Settings")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _magneticForce = 12f;
    public Polarity _targetPolarity;
    
    [Header("Collision")]
    [SerializeField] private float _extraDistance = 2f;
    private float _horizontalInput;
    private bool _isFacingRight = true;
    private Vector2 _direction;
    private Platform _targetPlatform;

    [Header("Other")]
    public GameObject UpPointer, RightPointer, DownPointer, LeftPointer;

    #endregion

    private void Update()
    {

        if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
        {  
            Flip();
        }

        MagnetismCheck();

        if (_targetPolarity == Polarity.North && Input.GetButton("NorthMagnet") || _targetPolarity == Polarity.South && Input.GetButton("SouthMagnet"))
        {
            if (_rigidBody.gravityScale != 0) _rigidBody.gravityScale = 0;
            _rigidBody.velocity = _direction * _speed;

        }

        if (_targetPolarity == Polarity.North && Input.GetButtonDown("SouthMagnet") || _targetPolarity == Polarity.South && Input.GetButtonDown("NorthMagnet"))
        {
            if (_rigidBody.gravityScale != 1) _rigidBody.gravityScale = 1;
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, (_direction.y * -1 * _magneticForce));
            
        }

        if (Input.GetButtonUp("NorthMagnet") || Input.GetButtonUp("SouthMagnet"))
        {
            _rigidBody.gravityScale = 1;
        }

        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");
        _direction = new Vector2(xDirection, yDirection);
        DrawDebugRays(_direction);
    }

    private void DrawDebugRays(Vector2 direction)
    {
        switch(direction)
        {
            case Vector2 v when v.Equals(Vector2.up):
                Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.up * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.up * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x, _boxCollider.bounds.extents.y + _extraDistance), Vector2.left * (_boxCollider.bounds.extents.x + 0.5f), Color.blue);
                UpPointer.SetActive(true);
                RightPointer.SetActive(false);
                DownPointer.SetActive(false);
                LeftPointer.SetActive(false);
                break;
            
            case Vector2 v when v.Equals(Vector2.right):
                Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x - 0.5f, 0.5f), Vector2.right * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x - 0.5f, -0.5f), Vector2.right * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x + _extraDistance, 0.5f), Vector2.down * (_boxCollider.bounds.extents.y + 0.5f), Color.blue);
                UpPointer.SetActive(false);
                RightPointer.SetActive(true);
                DownPointer.SetActive(false);
                LeftPointer.SetActive(false);
                break;
            
            case Vector2 v when v.Equals(Vector2.down):
                Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, _boxCollider.bounds.extents.y + _extraDistance), Vector2.right * (_boxCollider.bounds.extents.x + 0.5f), Color.blue);
                UpPointer.SetActive(false);
                RightPointer.SetActive(false);
                DownPointer.SetActive(true);
                LeftPointer.SetActive(false);
                break;
            
            case Vector2 v when v.Equals(Vector2.left):
                Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x - 0.5f, -0.5f), Vector2.left * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x - 0.5f, 0.5f), Vector2.left * (_boxCollider.bounds.extents.y + _extraDistance), Color.blue);

                Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x + _extraDistance, 0.5f), Vector2.up * (_boxCollider.bounds.extents.y + 0.5f), Color.blue);
                UpPointer.SetActive(false);
                RightPointer.SetActive(false);
                DownPointer.SetActive(false);
                LeftPointer.SetActive(true);
                break;

            case Vector2 v when v.Equals(Vector2.zero):
                UpPointer.SetActive(false);
                RightPointer.SetActive(false);
                DownPointer.SetActive(false);
                LeftPointer.SetActive(false);
                break;
        }
    }

    private bool MagnetismCheck()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, _direction, _extraDistance, _groundLayer);

        if (raycastHit.collider != null)
        {
            _targetPlatform = raycastHit.collider.GetComponent<Platform>();
            _targetPolarity = _targetPlatform.ReturnPolarity();
        }
        else
        {
            _targetPlatform = null;
            _targetPolarity = Polarity.Neutral;
        }

        return raycastHit.collider != null;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
