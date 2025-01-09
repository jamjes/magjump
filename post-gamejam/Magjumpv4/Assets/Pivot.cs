using UnityEngine;

public class Pivot : MonoBehaviour
{
    Vector3 mouse_pos;
    Vector3 object_pos;
    Vector2 direction;
    float angle;

    private void Update() {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -10;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        direction.x = mouse_pos.x - object_pos.x;
        direction.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public float GetAngle() {
        return angle;
    }

    public Vector2 GetNormalDirection() {
        return direction.normalized;
    }
}
