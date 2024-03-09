using Assets.Scripts.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveFileUI : MonoBehaviour
{
    public Game SaveFile;

    public Text SaveName;
    public Text SaveLevel;

    private bool willLoadFile;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(_start_or_load);
    }

    private void _start_or_load()
    {
        if (willLoadFile)
        {
            SaveNumber._GAME_SAVE = SaveFile;
        }
        else
        {
            Game new_game = Game.StartNew(SaveName.text);
            SaveNumber._GAME_SAVE = new_game;
        }
        SceneManager.LoadSceneAsync((int)SaveNumber._GAME_SAVE.SceneNumber);
    }

    public void Set(Game Save, bool shouldLoad)
    {
        SaveFile = Save;

        willLoadFile = shouldLoad;
        SaveLevel.text = "Level: " + SaveFile.SceneNumber;
    }

    public void Empty(bool shouldLoad)
    {
        SaveFile = null;

        willLoadFile = shouldLoad;
        SaveLevel.text = "Empty";
    }
}
