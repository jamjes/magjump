using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    BoxCollider2D coll;
    private Vector2 direction;

    private enum DetectDirection {
        Up, Down, Left, Right
    };

    [SerializeField] private DetectDirection detectDirection;


    private void Awake() {
        coll = GetComponent<BoxCollider2D>();

        switch (detectDirection) {
            case DetectDirection.Up: direction = Vector2.up; break;
            case DetectDirection.Down: direction = Vector2.down; break;
            case DetectDirection.Left: direction = Vector2.left; break;
            case DetectDirection.Right: direction = Vector2.right; break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(coll.bounds.center, coll.bounds.size, 0, direction, .2f);

        foreach (RaycastHit2D hit in hits) {
            if (hit.collider.tag == "Player") {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(coll.bounds.center, coll.bounds.size, 0, Vector2.zero, .2f);

        foreach (RaycastHit2D hit in hits) {
            if (hit.collider.tag == "Player") {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
        }
    }
}
