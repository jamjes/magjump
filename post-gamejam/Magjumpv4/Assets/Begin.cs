using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(1);
        }
    }
}
