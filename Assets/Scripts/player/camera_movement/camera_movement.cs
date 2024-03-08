using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public new GameObject camera;
    public GameObject player;

    public float smooth_speed =  10.0f;


    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector2 player_position = player.transform.position;

        camera.transform.position = Vector2.Lerp(camera.transform.position, player_position, smooth_speed);
    }
}
