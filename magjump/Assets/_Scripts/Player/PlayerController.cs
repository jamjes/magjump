using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomVars;

public class PlayerController : MonoBehaviour
{
    private bool NorthField, SouthField;
    [SerializeField] private bool _canMagnetise;
    public PlayerMagnetismHandler MagnetismHandler {private set; get;}
    public Rigidbody2D RigidBody {private set; get;}
    public BoxCollider2D BoxCollider {private set; get;}
    public Vector2 Direction {private set; get;}

    //[SerializeField] private float _speed = 7f;
    //[SerializeField] private float _magneticForce = 12f;
    //[SerializeField] private LayerMask _groundLayer;
    //public Polarity _targetPolarity;
    //[SerializeField] private float _extraDistance = 2f;
    //private float _horizontalInput;
    //private bool _isFacingRight = true;
    //private Platform _targetPlatform;

    private void Start()
    {
        if (MagnetismHandler == null)
        {
            MagnetismHandler = GetComponent<PlayerMagnetismHandler>();
        }
    }
    
    private void Update()
    {
        GetInput();
        #region SHELVED
        //if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
        //{  
            //Flip();
        //}

        //MagnetismCheck();

        //if (_targetPolarity == Polarity.North && Input.GetButton("NorthMagnet") || _targetPolarity == Polarity.South && Input.GetButton//("SouthMagnet"))
        //{
            //if (_rigidBody.gravityScale != 1) _rigidBody.gravityScale = 1;
            //_rigidBody.velocity = new Vector2(_rigidBody.velocity.x, (Direction.y * -1 * _magneticForce));
            

        //}

        //if (_targetPolarity == Polarity.North && Input.GetButtonDown("SouthMagnet") || _targetPolarity == Polarity.South && Input.//GetButtonDown("NorthMagnet"))
        //{
            //if (_rigidBody.gravityScale != 0) _rigidBody.gravityScale = 0;
            //_rigidBody.velocity = Direction * _speed;
        //}

        //if (Input.GetButtonUp("NorthMagnet") || Input.GetButtonUp("SouthMagnet"))
        //{
           //_rigidBody.gravityScale = 1;
        //}

        //float xDirection = Input.GetAxisRaw("Horizontal");
        //float yDirection = Input.GetAxisRaw("Vertical");
        //Direction = new Vector2(xDirection, yDirection);
        #endregion
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow)) Direction = Vector2.up; 
        else if (Input.GetKey(KeyCode.RightArrow)) Direction = Vector2.right; 
        else if (Input.GetKey(KeyCode.DownArrow)) Direction = Vector2.down; 
        else if (Input.GetKey(KeyCode.LeftArrow)) Direction = Vector2.left; 
        else Direction = Vector2.zero; 

        if (_canMagnetise)
        {
            if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X)) NorthField = true; 
            else NorthField = false; 

            if (Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z)) SouthField = true; 
            else SouthField = false; 
        }
    }

    #region SHELVED

    //private bool MagnetismCheck()
    //{
        //RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Direction, //_extraDistance, _groundLayer);

        //if (raycastHit.collider != null)
        //{
            //_targetPlatform = raycastHit.collider.GetComponent<Platform>();
            //_targetPolarity = _targetPlatform.ReturnPolarity();
        //}
        //else
        //{
            //_targetPlatform = null;
            //_targetPolarity = Polarity.Neutral;
        //}

        //return raycastHit.collider != null;
    //}

    //private void Flip()
    //{
        //_isFacingRight = !_isFacingRight;
        //Vector3 localScale = transform.localScale;
        //localScale.x *= -1f;
        //transform.localScale = localScale;
    //}

    #endregion
}
