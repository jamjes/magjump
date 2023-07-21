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
}
