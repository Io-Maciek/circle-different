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

    public Game[] SavedGames = new Game[3];


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
            Debug.Log("No saves. Button stays inactive.");
            BtnLoadGame.GetComponent<Button>().interactable = false;
        }
        else
        {
            Debug.Log("Save found. Button becomes active!");
            BtnLoadGame.GetComponent<Button>().interactable = true;
        }
        NextCheckTime = Time.time + 10.0f;
    }


    private string CheckExistanceOfGameDirectory()
    {
        Debug.Log("Checking Directory...");
        var docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var game_dir = Path.Combine(docs, "CirclingDifferent");

        if (!Directory.Exists(game_dir))
        {
            Debug.Log("Created!");

            Directory.CreateDirectory(game_dir);
        }
        else
        {
            Debug.Log("OK.");
        }


        return game_dir;
    }

    private bool CheckExistanceOfSaveFile(int saveIndex, string game_dir_path)
    {
        Debug.Log($"Checking save {saveIndex}...");

        var save_file = Path.Combine(game_dir_path, $"save{saveIndex}.io");

        if (!File.Exists(save_file))
        {
            Debug.Log("No such save. FALSE");
            return false;
        }


        try
        {
            Game saved_game = IoFile.ReadFromString<Game>(File.ReadAllText(save_file));
            saved_game.Name = $"Save {saveIndex}";
            SavedGames[saveIndex] = saved_game;
            Debug.Log("OK. =\t"+saved_game);
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
