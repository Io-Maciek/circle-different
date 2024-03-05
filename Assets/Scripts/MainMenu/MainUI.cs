using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    public Button BtnQuitGame;

    void Start()
    {
        BtnQuitGame.onClick.AddListener(_quit_game);
    }

    void _quit_game()
    {
        Application.Quit();
    }
}
