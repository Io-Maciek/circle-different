using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject OptionsScreen;
    public GameObject DefaultScreen;

    bool isPaused = false;
    public bool isPressed = false;

    void Start()
    {
        
    }

    void Update()
    {
        var escape_key_axis = Input.GetAxisRaw("Cancel");
        if (escape_key_axis != 0.0f && !isPressed)
        {
            isPressed = true;
            HandlePauseScreen(!isPaused);
        }else if(escape_key_axis==0.0f && isPressed)
        {
            isPressed = false;
        }
    }

    private void HandlePauseScreen(bool isPaused)
    {
        if (isPaused)
        {
            ShowPauseMenu();
        }
        else
        {
            HidePauseMenu();
        }
    }

    public void HidePauseMenu()
    {
        Time.timeScale = 1.0f;
        OptionsScreen.SetActive(false);
        DefaultScreen.SetActive(true);
        PauseScreen.SetActive(false);
        isPaused = false;
    }

    private void ShowPauseMenu()
    {
        Time.timeScale = 0.0f;
        PauseScreen.SetActive(true);
        isPaused = true;
    }
}
