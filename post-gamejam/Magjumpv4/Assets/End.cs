using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(0);
        }
    }
}
