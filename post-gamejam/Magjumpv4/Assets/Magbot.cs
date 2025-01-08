using System.Collections;
using UnityEngine;

public class Magbot : MonoBehaviour {
    Vector2 targetDirection;
    public Pivot pivot;
    public Rigidbody2D rb;
    public float jumpForce = 16f;
    public BoxCollider2D coll;
    public LayerMask groundLayer;
    bool checkForApex = true;

    private void Update() {
        float angle = pivot.GetAngle();
        
        if (angle <= 10 && angle >= -10)            targetDirection = new Vector2(1, 0);
        else if (angle < 80 && angle > 10)          targetDirection = new Vector2(.5f, .8f);
        else if (angle <= 100 && angle >= 80)       targetDirection = new Vector2(0, 1);
        else if (angle < 170 && angle > 100)        targetDirection = new Vector2(-.5f, .8f);
        else if (angle <= -170 || angle >= 170)     targetDirection = new Vector2(-1, 0);
        else if (angle < -100 && angle > -170)      targetDirection = new Vector2(-.5f, -.8f);
        else if (angle <= -80 && angle >= -100)     targetDirection = new Vector2(0, -1);
        else if (angle <= -10 && angle >= -80)      targetDirection = new Vector2(.5f, -.8f);

        if (Input.GetMouseButtonDown(1)) {
            if (IsGrounded()) Repel(); checkForApex = true;
        }

        if (rb.linearVelocityY < .5f && rb.linearVelocityY > -.5f && IsGrounded() == false) {
            if (checkForApex == false) {
                return;
            }

            StartCoroutine(ApexJump());
            checkForApex = false;
        }
    }

    private void Repel() {
        rb.linearVelocity = targetDirection * jumpForce * -1;
    }

    private bool IsGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .2f, groundLayer);
        return hit.collider != null;
    }

    private IEnumerator ApexJump() {
        rb.gravityScale = 0;
        rb.linearVelocityY = 0;
        yield return new WaitForSeconds(.15f);
        rb.gravityScale = 1;
    }
}



/*Vector2 direction;
Rigidbody2D rb;
BoxCollider2D coll;
[SerializeField] float jumpForce = 12;
[SerializeField] float velocityY;
bool isGrounded;
[SerializeField] LayerMask groundLayer;
bool canApex = false;
[SerializeField] Vector2 angle;

private void Awake() {
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
}

private void Update() {
    isGrounded = IsGrounded();

    *//*if (Input.GetMouseButtonDown(0)) {
        Vector2 mouse_pos;
        Vector3 object_pos;

        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = (int)(mouse_pos.x - object_pos.x);
        mouse_pos.y = (int)(mouse_pos.y - object_pos.y);

        direction = mouse_pos.normalized;
        angle = direction;
        Push();
    }
    else *//*
    Vector2 mouse_pos;
    Vector3 object_pos;

    mouse_pos = Input.mousePosition;
    object_pos = Camera.main.WorldToScreenPoint(transform.position);
    mouse_pos.x = (int)(mouse_pos.x - object_pos.x);
    mouse_pos.y = (int)(mouse_pos.y - object_pos.y);
    direction = mouse_pos.normalized * -1;
    angle = direction;

    if (Input.GetMouseButtonDown(1) && isGrounded) {



        *//*if (direction.x > .25f && direction.x < .45f) {
            direction = new Vector2(.45f, .85f);
        }
        else if (direction.x < -.25f && direction.x > -.45f) {
            direction = new Vector2(-.45f, .85f);
        }*//*

        Push();
    }

    velocityY = rb.linearVelocityY;

    if ((velocityY < .5f && velocityY > -.5f) && (isGrounded == false && canApex == false)) {
        canApex = true;
        StartCoroutine(Apex());
    }
    else if (isGrounded) {
        canApex = false;
    }
}

private void Push() {
    rb.linearVelocity = direction * jumpForce;
}

private bool IsGrounded() {
    RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .2f, groundLayer);
    return hit.collider != null;
}

IEnumerator Apex() {
    rb.gravityScale = 0;
    rb.linearVelocityY = 0;
    yield return new WaitForSeconds(.15f);
    rb.gravityScale = 1;
}*/