using UnityEngine;

public class WinCondition : MonoBehaviour
{
    BoxCollider2D coll;

    private void Awake() {
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(coll.bounds.center, coll.bounds.size, 0, Vector2.up, .2f); // * .8f

        foreach (RaycastHit2D hit in hits) {
            if (hit.collider.tag == "Player") {
                Debug.Log("Win Condition has been met!");
                return;
            }
        }
    }
}
