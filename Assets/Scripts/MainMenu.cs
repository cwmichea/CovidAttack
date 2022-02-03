using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AsyncOperation async;// Go on to the next scene(LEVEL1)
    [Header("First item in these list will be selected by (default)")]
    [SerializeField] private GameObject[] panels = null;//list of all the panels
    [SerializeField] private Selectable[] defaultBtn = null;// not just for buttons select the default UI

    public void PanelToggle(int position)//enable one specific panel and select its defauult button
    {
        for (int i = 0; i < panels.Length; i++)//loop for every panels in the list
        {//enable disable the panel
            panels[i].SetActive(position == i);//posiiton ==i : true or false... smart coding

            if (position == i)
            {

                defaultBtn[i].Select();//set the focus on that button
            }
        }
    }
    void Start()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(false);
    }
    public void LoadHistory()
    {
        PanelToggle(0);
    }
    public void LoadInstructionsandControl()
    {
        PanelToggle(1);
    }
    public void LoadScene()
    {
        if (async != null)
        {
            return;//Stop giving a second order if it is already loading
        }
        Scene currentScene = SceneManager.GetActiveScene();//Get the current scene(in this case StartPoint)
        async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);//Load the next scene
    }
    public void ExitGame()
    {
        
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//exit the playmode in the editor
#else
        Application.Quit();
#endif
        Application.Quit();
    }
}
