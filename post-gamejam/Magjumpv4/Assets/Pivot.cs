using UnityEngine;

public class Pivot : MonoBehaviour
{
    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    private void Update() {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -10;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public float GetAngle() {
        return angle;
    }
}
