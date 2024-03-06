using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public new GameObject camera;
    public GameObject player;

    public float smooth_speed =  10.0f;

    public float ZoomInGravity = 0.1f;
    public float ZoomOutForce = 0.2f;
    public float MaxZoomOut = 7.0f;
    private float DefaultZoomIn = 0.0f;

    public float TimeToStartZoomingOut = 1.0f;

    private float StartedMovingTime = 0.0f;
    bool is_moving = false;

    public bool TurnOnZooming = false;

    private void Start()
    {
        DefaultZoomIn = camera.GetComponent<Camera>().orthographicSize;
    }

    private void Update()
    {
        Vector2 player_position = player.transform.position;
        
        camera.transform.position = Vector2.Lerp(camera.transform.position, player_position, smooth_speed * Time.deltaTime);

        if(TurnOnZooming)
            CameraHandleZoom();
    }

    private void CameraHandleZoom()
    {
        float start_zoom = camera.GetComponent<Camera>().orthographicSize;
        float out_zoom = start_zoom;

        if (GetComponent<player_movement>().MoveIsBlocked || (
            Input.GetAxisRaw("Horizontal") == 0.0f & Input.GetAxisRaw("Vertical") == 0.0f)) // not moving
        {
            if (is_moving)
            {
                is_moving = false;
            }
            out_zoom = Mathf.Clamp(start_zoom- (ZoomInGravity * Time.deltaTime), DefaultZoomIn, MaxZoomOut);
        }
        else
        {
            if (!is_moving)
            {
                is_moving = true;

                if (start_zoom == DefaultZoomIn)
                    StartedMovingTime = Time.time + TimeToStartZoomingOut;
                else
                    StartedMovingTime = Time.time;
            }

            if (Time.time >= StartedMovingTime)
            {
                // Calculate the elapsed time since movement started
                float time_difference = Time.time - StartedMovingTime;

                // Calculate the logarithmic factor to adjust zoom increment
                float time_log = Mathf.Log(1 + time_difference) / Mathf.Log(1 + TimeToStartZoomingOut);

                // Adjust the zoom out force based on the logarithmic factor
                float zoom_log_force = ZoomOutForce * time_log;

                // Update the out_zoom using adjusted zoom out force
                out_zoom = Mathf.Clamp(start_zoom + (zoom_log_force * Time.deltaTime), DefaultZoomIn, MaxZoomOut);
            }
        }

        if (start_zoom != out_zoom)
        {
            camera.GetComponent<Camera>().orthographicSize = out_zoom;
        }
    }
}
