using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] WayPoints;
    private float speed = 2f;
    private int currentIndex;

    private void Start() {
        currentIndex = 0;
        transform.position = WayPoints[currentIndex].position;

    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, WayPoints[currentIndex + 1].position, speed * Time.deltaTime);

        if (transform.position == WayPoints[currentIndex + 1].position) {
            currentIndex++;

            if (currentIndex == WayPoints.Length - 1) {
                currentIndex = -1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            collision.gameObject.transform.parent = null;
        }
    }
}
