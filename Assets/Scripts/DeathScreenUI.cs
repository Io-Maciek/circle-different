using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenUI : MonoBehaviour
{
    public Button BtnExit;
    public Button BtnRestart;

    void Start()
    {
        BtnExit.onClick.AddListener(_exit_to_menu);
        BtnRestart.onClick.AddListener(_restart_level);
    }

    private void _restart_level()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void _exit_to_menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(0);
    }
}
