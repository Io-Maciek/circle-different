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
    public Button BtnOpenAboutScreen;
    public Button BtnLoadNewGame;

    public GameObject OptionsScreen;
    public GameObject AboutScreen;
    public GameObject SavesScreen;
    public List<AudioSource> _audios;

    void Start()
    {
        BtnQuitGame.onClick.AddListener(_quit_game);
        BtnOpenOptionsScreen.onClick.AddListener(_open_options);
        BtnStartNewGame.onClick.AddListener(_new_game);
        BtnOpenAboutScreen.onClick.AddListener(_open_about);
        BtnLoadNewGame.onClick.AddListener(_load_game);

        OptionsSetup();
    }



    private void _open_about()
    {
        AboutScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    private void _new_game()
    {
        SavesScreen.SetActive(true);
        SavesScreen.GetComponent<SavesScreen>().Set(false);
        gameObject.SetActive(false);
    }

    private void _load_game()
    {
        SavesScreen.SetActive(true);
        SavesScreen.GetComponent<SavesScreen>().Set(true);
        gameObject.SetActive(false);
    }

    void OptionsSetup()
    {
        var options = new Options();
        foreach(var audio  in _audios)
        {
            audio.volume = options.MasterSound;
        }
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
