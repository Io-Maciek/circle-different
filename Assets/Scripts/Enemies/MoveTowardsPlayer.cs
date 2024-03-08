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


    void Start()
    {
        player_ability = player.GetComponentInParent<BecomeSquareAbility>();
        RestDefaultPosition = transform.position;
        rigid_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 8.0f && player_ability.IsCircle)
            {
                IsAgressive = true;
            }
            else
            {
                IsAgressive = false;
            }
        }
        catch (MissingReferenceException)
        {
            IsAgressive = false;
        }
    }

    private void FixedUpdate()
    {
        if (IsAgressive)
        {
            ChasePlayer();
        }
        else if(!_reached_home)
        {
            GoToSpawn();
        }
        else
        {
            rigid_body.velocity = Vector3.zero;
        }
    }

    private void ChasePlayer()
    {
        _reached_home = false;
        TravelTo(player.transform.position);
    }

    private void GoToSpawn()
    {
        float distance_to_spawn = Vector3.Distance(transform.position, RestDefaultPosition);
        if (distance_to_spawn > 1.25f)
        {
            TravelTo(RestDefaultPosition);
        }
        else
        {
            _reached_home = true;
        }
    }


    void TravelTo(Vector2 target)
    {
        Vector2 toTarget = (target - (Vector2)transform.position).normalized;
        rigid_body.velocity = toTarget * runSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player && player_ability.IsCircle)
        {
            //TODO show UI to load scene or exit
            Destroy(player);
        }
    }
}
