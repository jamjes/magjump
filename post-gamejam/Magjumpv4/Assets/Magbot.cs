using System.Collections;
using UnityEngine;

public class Magbot : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    BoxCollider2D coll;
    [SerializeField] float jumpForce = 12;
    [SerializeField] float velocityY;
    bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    bool canApex = false;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        isGrounded = IsGrounded();

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
    }
}
