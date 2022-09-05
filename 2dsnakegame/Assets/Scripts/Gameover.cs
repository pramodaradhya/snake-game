using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Button buttonrestart;
    private void Awake()
    {
        buttonrestart.onClick.AddListener(ReloadLevel);

    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
}
