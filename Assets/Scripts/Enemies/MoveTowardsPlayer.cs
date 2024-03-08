using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public GameObject player;
    BecomeSquareAbility player_ability;
    Rigidbody2D rigid_body;

    Vector2 RestDefaultPosition;
    public bool IsAgressive = false;
    public float runSpeed = 1.0f;

    bool _reached_home = true;

    public float SecondsTimeToWaitAfterLoosingPlayer = 5.0f;
    private float _timeToGoHome = 0.0f;


    void Start()
    {
        player_ability = player.GetComponentInParent<BecomeSquareAbility>();
        RestDefaultPosition = transform.position;
        rigid_body = GetComponent<Rigidbody2D>();
    }


    Vector2 _last_known_player_pos;

    // Update is called once per frame
    void Update()
    {
        try
        {
            var _player_pos = player.transform.position;
            float distance = Vector3.Distance(transform.position, _player_pos);
            if (distance < 8.0f && player_ability.IsCircle)
            {
                _last_known_player_pos = _player_pos;
                if (!IsAgressive)
                {
                    IsAgressive = true;
                }
            }
            else if (IsAgressive)
            {
                _timeToGoHome = Time.time + SecondsTimeToWaitAfterLoosingPlayer;
                IsAgressive = false;
            }
        }
        catch (MissingReferenceException)
        {
            if (IsAgressive)
                IsAgressive = false;
        }
    }

    private void FixedUpdate()
    {
        var _now_time = Time.time; ;
        if (IsAgressive)
        {
            ChasePlayer();
        }else if(_now_time < _timeToGoHome)
        {
            SearchLastKnownPosition();
        }
        else if (!_reached_home)
        {
            GoToSpawn();
        }
        else
        {
            rigid_body.velocity = Vector3.zero;
        }
    }

    private void SearchLastKnownPosition()
    {
        if (AchivedPosition(_last_known_player_pos, 1.25f))
        {
            if(rigid_body.velocity != (Vector2)Vector3.zero)
                rigid_body.velocity = Vector3.zero;
        }
        else
        {
            TravelTo(_last_known_player_pos);
        }
    }

    private void ChasePlayer()
    {
        _reached_home = false;
        TravelTo(_last_known_player_pos);
    }

    private void GoToSpawn()
    {
        if (AchivedPosition(RestDefaultPosition))
        {
            if (!_reached_home)
                _reached_home = true;
        }
        else
        {
            TravelTo(RestDefaultPosition);
        }
    }
    bool AchivedPosition(Vector2 target, float distance = 1.25f)
    {
        return Vector3.Distance(transform.position, target) < distance;
    }

    void TravelTo(Vector2 target)
    {
        Vector2 toTarget = (target - (Vector2)transform.position).normalized;
        rigid_body.velocity = toTarget * runSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player && player_ability.IsCircle)
        {
            //TODO show UI to load scene or exit
            player.transform.GetComponentInParent<ActivateDeath>().Die();
        }
    }
}
