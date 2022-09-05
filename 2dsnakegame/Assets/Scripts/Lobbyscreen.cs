using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobbyscreen : MonoBehaviour
{
    public Button Play;
    public Button buttonExit;


    private void Awake()
    {

        Play.onClick.AddListener(Playgame);

     /*   if (GameObject.FindWithTag("Exit"))
        {
            buttonExit.onClick.AddListener(ExitLevel);
        }*/
    }

    private void Playgame()
    {
        SceneManager.LoadScene("GameScene");
    }

/*    public void ExitLevel() 
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.Quit();
    }*/
}