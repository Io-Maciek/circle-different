using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    public Button BtnStartNewGame;

    public Button BtnQuitGame;
    public Button BtnOpenOptionsScreen;

    public GameObject OptionsScreen;
    public new AudioSource audio;

    void Start()
    {
        BtnQuitGame.onClick.AddListener(_quit_game);
        BtnOpenOptionsScreen.onClick.AddListener(_open_options);
        BtnStartNewGame.onClick.AddListener(_new_game);

        OptionsSetup();
    }

    private void _new_game()
    {
        SceneManager.LoadSceneAsync(1);
    }

    void OptionsSetup()
    {
        var options = new Options();
        audio.volume = options.MasterSound;
        options.Apply();
    }

    void _quit_game()
    {
        Application.Quit();
    }

    void _open_options()
    {
        OptionsScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
