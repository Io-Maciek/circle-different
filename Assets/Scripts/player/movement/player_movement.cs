using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class player_movement : MonoBehaviour
{
    //Rigidbody2D rb;
    public float Move_After_Seconds = 0.5f;

    private float _SIZE;
    float _NEXT_MOVE_TIME;


    GameObject player;
    float ColliderAdderDetection = 0.05f;

    bool _move_is_being_handle = false;
    PlayerObjectController playerObjectController;

    public bool MoveIsBlocked = false;


    private void Start()
    {
        playerObjectController = GetComponent<camera_movement>().player.GetComponent<PlayerObjectController>();
        player = GetComponent<camera_movement>().player;

        //rb = GetComponent<Rigidbody2D>();
        _SIZE = playerObjectController.Circle.GetComponent<SpriteRenderer>().bounds.size.x;
        _NEXT_MOVE_TIME = 0.0f;

    }

    private void Update()
    {
        if (!_move_is_being_handle)// && Time.time >= _NEXT_MOVE_TIME)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if ((horizontal != 0.0f || vertical != 0.0f) && (horizontal==0.0f || vertical == 0.0f))
            {
                _move_is_being_handle = true;
                MakeMove(horizontal, vertical);
            }
        }
/*        else
        {
            if (Time.time - _anim_start < _anim_duration)
            {
                player.transform.position = Vector3.Lerp(_anim_start_position, _move_target, (Time.time - _anim_start) / _anim_duration);
            }
            else
            {
                player.transform.position = _move_target;
                _move_is_being_handle = false;
            }
        }*/
    }




    private IEnumerator MoveToTarget(Vector3 target)
    {
        var now = Time.time;

        _NEXT_MOVE_TIME = now + Move_After_Seconds;
        Vector3 startPosition = player.transform.position;
        float startTime = now;
        float duration = _NEXT_MOVE_TIME - startTime;

        while (Time.time - startTime < duration)
        {
            player.transform.position = Vector3.Lerp(startPosition, target, (Time.time - startTime) / duration);
            yield return new WaitForEndOfFrame();
        }

        // Ensure final position
        player.transform.position = target;
        _move_is_being_handle = false;
    }

/*    public Vector3 _move_target;
    public Vector3 _anim_start_position;

    public float _anim_start;
    public float _anim_duration;*/

    private void MakeMove(float horizontal, float vertical)
    {
        var positions = CheckMovementCollision(horizontal, vertical);

        var h = Mathf.Round(player.transform.position.x + _SIZE * positions.Item1);
        var v = Mathf.Round(player.transform.position.y + _SIZE * positions.Item2);

        Vector3 target = new Vector3(h,v, player.transform.position.z);
/*        _move_target = target;

        _anim_start = Time.time;
        _NEXT_MOVE_TIME = _anim_start + Move_After_Seconds;
        _anim_duration= _NEXT_MOVE_TIME - _anim_start;
        _anim_start_position = player.transform.position;

        _move_is_being_handle = true;*/
        StartCoroutine(MoveToTarget(target));
    }


    (float, float) CheckMovementCollision(float horizontal, float vertical)
    {
        var vertical_position = 0.0f;
        var horizontal_position = 0.0f;

        if (vertical < 0.0f) // is walking down
        {
            if (RayHitNothing(new Vector2(player.transform.position.x, player.transform.position.y - ColliderAdderDetection) + new Vector2(0.0f, (-1 * _SIZE) / 2.0f), new Vector2(0.0f, -1 * _SIZE + 2 * ColliderAdderDetection)))
            {
                vertical_position = vertical;
            }
        }
        else if (vertical > 0.0f)
        {
            if (RayHitNothing(new Vector2(player.transform.position.x, player.transform.position.y - ColliderAdderDetection) + new Vector2(0.0f, (3 * _SIZE) / 2.0f), new Vector2(0.0f, -1 * _SIZE + 2 * ColliderAdderDetection)))
            {
                vertical_position = vertical;
            }
        }

        if (horizontal > 0.0f) // is walking right
        {
            if (RayHitNothing(new Vector2(player.transform.position.x - ColliderAdderDetection, player.transform.position.y) + new Vector2((3 * _SIZE) / 2.0f, 0.0f)
                , new Vector2(-1 * _SIZE + 2 * ColliderAdderDetection, 0.0f)))
            {
                horizontal_position = horizontal;
            }
        }
        else if (horizontal < 0.0f)
        {
            if (RayHitNothing(new Vector2(player.transform.position.x - ColliderAdderDetection, player.transform.position.y) + new Vector2((-1 * _SIZE) / 2.0f, 0.0f)
                , new Vector2(-1 * _SIZE + 2 * ColliderAdderDetection, 0.0f)))
            {
                horizontal_position = horizontal;
            }
        }
        return (horizontal_position, vertical_position);
    }

    private bool RayHitNothing(Vector2 StartVec2, Vector2 DirectionVec2)
    {
        var ray = Physics2D.Raycast(StartVec2, DirectionVec2, _SIZE - 2* ColliderAdderDetection);

        if (ray.collider == null)
        {
            MoveIsBlocked = false;
            return true;
        }
        else
        {
            MoveIsBlocked = true;
#if DEBUG
            Debug.DrawRay(StartVec2, DirectionVec2, Color.red, .5f);
            //Debug.Log(ray.collider);
#endif
            return false;
        }
    }
}
