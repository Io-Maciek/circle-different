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


    public float NextCheckTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
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
        NextCheckTime = Time.time + 10.0f;
    }


    private string CheckExistanceOfGameDirectory()
    {
        var docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var game_dir = Path.Combine(docs, "CirclingDifferent");

        if (!Directory.Exists(game_dir))
        {
            Directory.CreateDirectory(game_dir);
        }

        return game_dir;
    }

    private bool CheckExistanceOfSaveFile(int saveIndex, string game_dir_path)
    {
        var save_file = Path.Combine(game_dir_path, $"save{saveIndex}.io");

        if (!File.Exists(save_file))
        {
            return false;
        }


        try
        {
            Game saved_game = IoFile.ReadFromString<Game>(File.ReadAllText(save_file));
            saved_game.Name = $"Save {saveIndex}";
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
    }

    private void Update()
    {
        if(Time.time >= NextCheckTime)
        {
            Debug.Log("===Next check===");
            CheckDirectoryAndSaves();
        }
    }

}
