using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    public Button BtnQuitGame;
    public Button BtnOpenOptionsScreen;

    public GameObject OptionsScreen;

    void Start()
    {
        BtnQuitGame.onClick.AddListener(_quit_game);
        BtnOpenOptionsScreen.onClick.AddListener(_open_options);

        OptionsSetup();
    }


    void OptionsSetup()
    {
        var options = new Options();
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
