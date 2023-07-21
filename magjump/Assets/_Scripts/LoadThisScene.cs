using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadThisScene : MonoBehaviour
{
    public string SceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName); //Load this scene when function is called
    }

    public void Exit()
    {
        Application.Quit(); //Exit application when function is called
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(DelayScene(1.5f));
        }
    }

    IEnumerator DelayScene(float value)
    {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(SceneName);
    }
}
