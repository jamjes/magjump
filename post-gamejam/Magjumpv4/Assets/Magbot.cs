using System.Collections;
using UnityEngine;

public class Magbot : MonoBehaviour {
    public string Debug_Message;

    Vector2 targetDirection;
    public ScreenShake camShake;
    public Pivot pivot;
    public Rigidbody2D rb;
    public float jumpForce = 16f;
    public BoxCollider2D coll;
    public LayerMask groundLayer;
    bool checkForApex = true;
    public Vector2 direction;
    public bool canStick;

    float jumpTimeRef;
    float delayTime = .1f;

    private void Update() {
        float angle = pivot.GetAngle();
        bool isGrounded = IsGrounded();

        if (angle <= 10 && angle >= -10)            targetDirection = new Vector2(1, 0);
        else if (angle < 80 && angle > 10)          targetDirection = new Vector2(.5f, .8f);
        else if (angle <= 100 && angle >= 80)       targetDirection = new Vector2(0, 1);
        else if (angle < 170 && angle > 100)        targetDirection = new Vector2(-.5f, .8f);
        else if (angle <= -170 || angle >= 170)     targetDirection = new Vector2(-1, 0);
        else if (angle < -100 && angle > -170)      targetDirection = new Vector2(-.5f, -.8f);
        else if (angle <= -80 && angle >= -100)     targetDirection = new Vector2(0, -1);
        else if (angle <= -10 && angle >= -80)      targetDirection = new Vector2(.5f, -.8f);

        if (Input.GetMouseButtonDown(1)) {
            if (isGrounded) {
                Repel();
                checkForApex = true;
                jumpTimeRef = Time.time;
            }
        }
        else if (Input.GetMouseButtonDown(0)) {
            if (isGrounded) {
                Attract();
            }
        }

        if (Input.GetMouseButtonUp(1) && rb.linearVelocityY > 0) {
            rb.linearVelocityY = 0;
        }

        if (Input.GetMouseButton(0)) {
            canStick = true;
        }
        else if (Input.GetMouseButtonUp(0)) {
            if (rb.gravityScale == 0) {
                rb.gravityScale = 1;
                transform.parent = null;
            }
            
            canStick = false;
        }


        if (rb.linearVelocityY < .5f && rb.linearVelocityY > -.5f && isGrounded == false) {
            if (checkForApex == false) {
                return;
            }

            if (Time.time - jumpTimeRef < .3f) {
                delayTime = .05f;
            } else {
                delayTime = .1f;
            }

            StartCoroutine(ApexJump());
            checkForApex = false;
        }
    }

    private void Repel() {
        switch(targetDirection) {
            case Vector2 v when v == new Vector2(1, 0): Debug_Message = "RIGHT"; break;
            case Vector2 v when v == new Vector2(.5f, .8f): Debug_Message = "UP_RIGHT"; break;
            case Vector2 v when v == new Vector2(0, 1): Debug_Message = "UP"; break;
            case Vector2 v when v == new Vector2(-.5f, .8f): Debug_Message = "UP_LEFT"; break;
            case Vector2 v when v == new Vector2(-1, 0): Debug_Message = "LEFT"; break;
            case Vector2 v when v == new Vector2(-.5f, -.8f): Debug_Message = "DOWN_LEFT"; break;
            case Vector2 v when v == new Vector2(0, -1): Debug_Message = "DOWN"; break;
            case Vector2 v when v == new Vector2(.5f, -.8f): Debug_Message = "DOWN_RIGHT"; break;
        }

        rb.linearVelocity = targetDirection * jumpForce * -1;
    }

    private void Attract() {
        rb.linearVelocity = targetDirection * jumpForce;
    }

    private bool IsGrounded() {
        direction = pivot.GetNormalDirection();
        RaycastHit2D[] hits = Physics2D.BoxCastAll(coll.bounds.center, coll.bounds.size, 0, direction, 2.5f, groundLayer);
        foreach(RaycastHit2D hit in hits) {
            if (hit.collider != null) {
                return true;
            }
        }
        
        return false;
    }

    private IEnumerator ApexJump() {
        rb.gravityScale = 0;
        rb.linearVelocityY = 0;
        yield return new WaitForSeconds(delayTime);
        rb.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Attract") {
            transform.SetParent(collision.transform);
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;
            if (camShake != null) {
                camShake.started = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Repel") {
            if (camShake != null) {
                camShake.started = true;
            }
        }
    }
}