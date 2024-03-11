using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public new GameObject camera;
    public GameObject player;

    public float smooth_speed =  10.0f;

    Vector2 _last_player_pos;

    public GameObject JustAudio;


    private void Start()
    {
        _last_player_pos = player.transform.position;
        camera.transform.position = _last_player_pos;
    }

    private void Update()
    {
        try
        {
            JustAudio.transform.position = player.transform.position;
            _last_player_pos = player.transform.position;
        }
        catch (MissingReferenceException) { }
    }

    private void FixedUpdate()
    {
        camera.transform.position = Vector2.Lerp(camera.transform.position, _last_player_pos, smooth_speed);
    }
}
