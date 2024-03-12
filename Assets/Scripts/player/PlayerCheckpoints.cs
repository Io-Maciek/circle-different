using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpoints : MonoBehaviour
{
    public List<Vector2> CheckpointPosition;

    public int LastCheckpointIndex = 0;

    GameObject player;
    public GameObject instructions = null;

    void Start()
    {
        if(SaveNumber._GAME_SAVE == null)
        {
            SaveNumber._GAME_SAVE = new Game() { SceneNumber = (uint)SceneManager.GetActiveScene().buildIndex, Name = "DebugSave.io", CheckPointNumber = 0 };
            SaveNumber._GAME_SAVE.Save();
        }

        player = GetComponent<camera_movement>().player;
        CheckpointPosition.Insert(0, player.transform.position);

        LastCheckpointIndex = SaveNumber._GAME_SAVE.CheckPointNumber;
        player.transform.position = CheckpointPosition[SaveNumber._GAME_SAVE.CheckPointNumber];
        GetComponent<camera_movement>().camera.transform.position = CheckpointPosition[SaveNumber._GAME_SAVE.CheckPointNumber];

        if(instructions != null && LastCheckpointIndex == 0)
        {
            instructions.SetActive(true);
        }
    }


    public void CheckPointTriggerEnter(int checkpoint_number)
    {
        if (checkpoint_number > LastCheckpointIndex)
        {
            //Debug.Log("NOWY LEPSZY CHECK POINT "+checkpoint_number +"\t\t(from file PlayerCheckpoints.cs)");
            LastCheckpointIndex = checkpoint_number;
            SaveNumber._GAME_SAVE.CheckPointNumber = LastCheckpointIndex;
            SaveNumber._GAME_SAVE.Save();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportToLastCheckpoint()
    {
        player.transform.position = CheckpointPosition[LastCheckpointIndex];
    }
}
