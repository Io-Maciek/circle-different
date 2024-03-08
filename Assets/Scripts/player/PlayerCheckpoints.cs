using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoints : MonoBehaviour
{
    public List<Vector2> CheckpointPosition;

    public int LastCheckpointIndex = 0;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<camera_movement>().player;
        CheckpointPosition.Insert(0, player.transform.position);
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
