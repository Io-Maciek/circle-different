using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject OptionsScreen;

    List<AudioSource> audioSource;
    List<float> audioLevels;

    public GameObject DefaultScreen;
    public GameObject Hider;

    bool isPaused = false;
    public bool isPressed = false;

    void Start()
    {
        Hider.SetActive(true);
        audioSource = OptionsScreen.GetComponent<OptionsScript>().audioSource;
        audioLevels = OptionsScreen.GetComponent<OptionsScript>().audioSourceDefaultValues;

        OptionsApplyOnStart();
    }


    void OptionsApplyOnStart()
    {
        var _options = new Options();
        for(int i = 0; i < audioSource.Count; i++)
        {
            try
            {
                audioSource[i].volume = _options.MasterSound * audioLevels[i];
            }
            catch (Exception)
            {
                audioSource[i].volume = _options.MasterSound;
            }
        }
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
        OptionsScreen.GetComponent<OptionsScript>().OptionsApply();
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
