using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreenButtons : MonoBehaviour
{
    public Button BtnExitToMenu;
    public Button BtnOpenOptions;
    public Button BtnResumeGame;

    public GameObject OptionsScreen;
    public GamePause GamePauser;


    void Start()
    {
        BtnExitToMenu.onClick.AddListener(_exit_to_menu);
        BtnOpenOptions.onClick.AddListener(_open_options);
        BtnResumeGame.onClick.AddListener(_resume_game);
    }

    private void _resume_game()
    {
        GamePauser.HidePauseMenu();
    }

    private void _open_options()
    {
        OptionsScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    private void _exit_to_menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(0);
        // todo saving for example
    }
}
