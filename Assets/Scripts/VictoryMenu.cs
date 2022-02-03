using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    private AsyncOperation async;//
    // Go on to the next scene(LEVEL1)
    public void Replay()
    {
        if (async != null)
        {
            return;//Stop giving a second order if it is already loading
        }
        Scene currentScene = SceneManager.GetActiveScene();//Get the current scene(in this case StartPoint)
        async = SceneManager.LoadSceneAsync(currentScene.buildIndex - 1);//Load again the previous scene
    }
    public void GoToMainMenu()
    {
        if (async != null)
        {
            return;//Stop giving a second order if it is already loading
        }
        Scene currentScene = SceneManager.GetActiveScene();//Get the current scene(in this case StartPoint)
        async = SceneManager.LoadSceneAsync("StartPoint");//Load

    }
}
