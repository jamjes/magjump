using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 7f, _jumpForce = 12f;
    private float _horizontalInput;
    private bool _isFacingRight = true;

    [SerializeField] private Rigidbody2D _rigidBody;    
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _groundLayer;

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_horizontalInput * _speed, _rigidBody.velocity.y);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_feetPosition.position, 0.2f, _groundLayer);
    }
}
