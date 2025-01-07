using UnityEngine;

public class Player : MonoBehaviour {

    Vector2 direction;
    float dir;
    Rigidbody2D rb;
    float force = 12f;
    float speed = 8f;
    PlayerMovement movement;
    [SerializeField] LayerMask groundLayer;
    BoxCollider2D coll;
    float jumpForce = 12f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        movement = new PlayerMovement(rb, coll);
        movement.InitMove(speed);
        movement.InitJump(jumpForce, groundLayer);
    }

    private void Update() {
        movement.LogicUpdate();
    }

    private void FixedUpdate() {
        movement.PhysicsUpdate();
    }

    private void Push() {
        rb.linearVelocity = direction * force;
    }

    private void Movement() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mouse_pos;
            Vector3 object_pos;

            mouse_pos = Input.mousePosition;
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = (int)(mouse_pos.x - object_pos.x);
            mouse_pos.y = (int)(mouse_pos.y - object_pos.y);

            direction = mouse_pos.normalized;
            Push();
        }
        else if (Input.GetMouseButtonDown(1)) {
            Vector2 mouse_pos;
            Vector3 object_pos;

            mouse_pos = Input.mousePosition;
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = (int)(mouse_pos.x - object_pos.x);
            mouse_pos.y = (int)(mouse_pos.y - object_pos.y);

            direction = mouse_pos.normalized * -1;
            Push();
        }
    }
}

public class PlayerMovement {
    private Rigidbody2D _rb;
    private BoxCollider2D _coll;
    private float _direction;
    private float _speed;
    private LayerMask _groundLayer;
    private float _jumpForce;
    private CollisionCheck groundCheck;
    private bool _isGrounded;

    private bool canMove, canJump;

    public PlayerMovement(Rigidbody2D rb, BoxCollider2D coll) {
        _rb = rb;
        _coll = coll;
    }

    public void InitMove(float speed) {
        _speed = speed;
        canMove = true;
    }

    public void InitJump(float jumpForce, LayerMask groundLayer) {
        _jumpForce = jumpForce;
        _groundLayer = groundLayer;
        groundCheck = new CollisionCheck();
        canJump = true;
    }

    public void LogicUpdate() {
        _direction = Input.GetAxisRaw("Horizontal");
        _isGrounded = groundCheck.IsColliding(_coll, Vector2.down, _groundLayer);

        if (canJump == false) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) {
            _rb.linearVelocityY = _jumpForce;
        }
    }

    public void PhysicsUpdate() {
        if (canMove == false) {
            return;
        }

        _rb.linearVelocityX = _speed * _direction;
    }
}

public class CollisionCheck {
    public bool IsColliding(BoxCollider2D objectCollider, Vector2 targetDirection, LayerMask targetLayer) {
        RaycastHit2D hit = Physics2D.BoxCast(objectCollider.bounds.center, objectCollider.bounds.size, 0, targetDirection, 0.2f, targetLayer);
        return hit.collider != null;
    }
}
