using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //Make possible to referere from any script. It can call it out for others.
    public static GameManager instance = null;
    //Work with scenes managementes
    private AsyncOperation async;//
    public string sceneToReload = "Level1";
    public string VictoryScene = "Victory";
    //User Interface
    //score counter
    public Text rscoreText;
    public Text wscoreText;
    private int rpill = 0;
    private int totalRPill = 0;
    private int wpill = 0;
    private int totalWPill = 0;
    //lives counter
    public Text livesText;
    public int lives = 3;
    //timer
    public Text timerText;
    private float timer =180f;
    private string minutes;//minute counter
    private string seconds;//second counter
    public bool timerON = true;//to pause
    public float timeSaved = 180f;// to get on track again 

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)//Create a new instance if there is any created  
        {
            instance = this;
        }
        else if (instance != this)//Block the old GameManager to oblige use a new one
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //timerText.text = " ";
        seconds = " ";
        minutes = " ";
    }
    //Pause
    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("Paused pressed");
        bool ON = context.performed;
        if (timerON)
        {
            timerON = false;
        }
        else
        {
            timerON = true;
        }
    }
    // Update is called once per frame
    void Update()
    {   //score update
        rscoreText.text = rpill.ToString("00") +"/"+ totalRPill.ToString("00");
        wscoreText.text = wpill.ToString("00") + "/" + totalWPill.ToString("00");
        livesText.text = "Lives : " + lives.ToString("00");
        //timer in process
        if (timerON)
        {
            timer -= Time.deltaTime;
            minutes = Mathf.Floor(timer / 60).ToString("00");//truncate the number to get min
            seconds = (timer % 60).ToString("00");
            timerText.text =  minutes+ ":" +seconds;
            timeSaved = timer;
            if (timer <= 0)
            {
                GameOver();
            }
        }
        else
        {
            Debug.Log("TIME IN PAUSE");
        }
    }
    public void AddRScore() 
    {
        Debug.Log("+100 points");
        rpill++;
    }
    public void AddWScore()
    {
        Debug.Log("+100 points");
        wpill++;
    }
    public void AddRPill()
    {
        totalRPill++;
    }
    public void AddWPill()
    {
        totalWPill++;
    }
    public void Victory()
    {
        Debug.Log("VICTORY");
        if (async != null)
        {
            return;//Stop giving a second order if it is already loading
        }
        //Scene currentScene = SceneManager.GetActiveScene();//Get the current scene(in this case StartPoint)
        async = SceneManager.LoadSceneAsync(VictoryScene);//Load
    }
    public void Restart()
    {
        SceneManager.LoadScene(sceneToReload);
    }
    public void Damage()
    {
        lives--;
        if (lives<=0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        timerON = false;
        SceneManager.LoadScene("GameOver");
        //    menuMode = true;
        //    destructionTime = 0;
        //    Debug.Log("ReloadScene");
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    btnReload.SetActive(true);
        //    btnExit.SetActive(true);
        //    redPanel.SetActive(true);
        //    resultText.text = "Results:" + (14 - fires) * 50 + "/700";
        //    bigText.text = "GameOver";
    }
}
