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
    public Vector2 Direction {private set; get;}
    private Platform _targetPlatform;

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
            if (_rigidBody.gravityScale != 1) _rigidBody.gravityScale = 1;
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, (Direction.y * -1 * _magneticForce));
            

        }

        if (_targetPolarity == Polarity.North && Input.GetButtonDown("SouthMagnet") || _targetPolarity == Polarity.South && Input.GetButtonDown("NorthMagnet"))
        {
            if (_rigidBody.gravityScale != 0) _rigidBody.gravityScale = 0;
            _rigidBody.velocity = Direction * _speed;
        }

        if (Input.GetButtonUp("NorthMagnet") || Input.GetButtonUp("SouthMagnet"))
        {
            _rigidBody.gravityScale = 1;
        }

        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");
        Direction = new Vector2(xDirection, yDirection);
    }

    

    private bool MagnetismCheck()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Direction, _extraDistance, _groundLayer);

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
