using Assets.Scripts.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using IoDeSer;

public class LoadingSaves : MonoBehaviour
{
    public GameObject BtnLoadGame;

    public Game[] SavedGames = new Game[3] { null, null,null};


    float NextCheckTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SaveNumber._GAME_SAVE = null;
        CheckDirectoryAndSaves();
    }

    void CheckDirectoryAndSaves()
    {
        var game_dir = CheckExistanceOfGameDirectory();
        bool noneSavesExist = true;

        for (int i = 0; i < 3; i++)
        {
            if (CheckExistanceOfSaveFile(i, game_dir))
            {
                noneSavesExist = false;
            }
        }

        if (noneSavesExist)
        {
            BtnLoadGame.GetComponent<Button>().interactable = false;
        }
        else
        {
            BtnLoadGame.GetComponent<Button>().interactable = true;
        }
        NextCheckTime = Time.time + 5.0f;
    }


    private string CheckExistanceOfGameDirectory()
    {
#if UNITY_WEBGL
        return "";
#else
        var docs = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var game_dir = Path.Combine(docs, "CirclingDifferent");

        if (!Directory.Exists(game_dir))
        {
            Directory.CreateDirectory(game_dir);
        }

        return game_dir;
#endif

    }

    private bool CheckExistanceOfSaveFile(int saveIndex, string game_dir_path)
    {
#if UNITY_WEBGL
        var save_file = Path.Combine(game_dir_path, $"save{saveIndex}.io");
        SavedGames[saveIndex] = IoFile.ReadFromString<Game>(PlayerPrefs.GetString($"save{saveIndex}.io", "|||"));
        PlayerPrefs.Save();
        return SavedGames[saveIndex] != null;
#else
        var save_file = Path.Combine(game_dir_path, $"save{saveIndex}.io");

        if (!File.Exists(save_file))
        {
            return false;
        }


        try
        {
            Game saved_game = IoFile.ReadFromString<Game>(File.ReadAllText(save_file));
            //saved_game.Name = $"Save {saveIndex}";
            SavedGames[saveIndex] = saved_game;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
            SavedGames[saveIndex] = null;
            Debug.Log("Error in file. FALSE");
            return false;
        }


        return true;
#endif

    }

    private void Update()
    {
        if(Time.time >= NextCheckTime)
        {
            Debug.Log("===Next check===");
            SavedGames = new Game[3] { null, null, null };
            CheckDirectoryAndSaves();
        }
    }

}
