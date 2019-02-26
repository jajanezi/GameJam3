using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SimpleMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameGUI;
    public GameObject endMenu;
    public Transform moon;
    private Vector3 endCondition = new Vector3(0, 500, 0);
    private int counter;
    public TextMeshProUGUI deathText;
    public AudioClip deathNoise;

    #region Singleton

    public static SimpleMenu instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    void Start()
    {
        startMenu.SetActive(true);
    }


    void Update()
    {
      // if (Input.GetKeyDown(KeyCode.Escape))
     //   {
     //       Exit();
    //    }
        if(Time.deltaTime == 200f)
        {
            Time.timeScale = 0;
            gameGUI.SetActive(false);
            endMenu.SetActive(true);
        }
    }

    public void startGame()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel()
    {
       //determine the level the player is on, re-spawn at that level 

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Dead()
    {
        AudioManager.instance.RandomizeSfx(deathNoise);
        Time.timeScale = 0;
        gameGUI.SetActive(false);
        deathText.SetText("You Died. Sorry.");
        endMenu.SetActive(true);

    }
   
}
