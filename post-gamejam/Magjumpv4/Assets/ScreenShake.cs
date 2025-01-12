using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    public bool started;
    public float duration;
    public AnimationCurve intensity;

    private void Update() {
        if (started) {
            started = false;
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake() {
        Vector3 startPos = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = intensity.Evaluate(elapsedTime / duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;

        }

        transform.position = startPos;
    }
}
