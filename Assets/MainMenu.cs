using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Start Scene
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Main_scene");
    }

    //Main Menu Controller

    public void LoadMainScene()
    {
        SceneManager.LoadSceneAsync("Main_scene");
    }

    public void LoadScene1()
    {
        SceneManager.LoadSceneAsync("Copy_Scene1");
    }

    public void LoadScene2()
    {
        SceneManager.LoadSceneAsync("Copy_Scene1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
