using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In contrary to <see cref="player_movement"/> uses <see cref="Rigidbody2D"/> and property <c>velocity</c> to move
/// 
/// <para>
/// <see cref="player_movement"/> uses transform.position and raycasting
/// </para>
/// </summary>
public class BetterMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid_body;

    float horizontal;
    float vertical;

    public float runSpeed = 1.0f;

    void Start()
    {
        player = GetComponent<camera_movement>().player;
        rigid_body = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
    }

    private void FixedUpdate()
    {
        try
        {
            if (Mathf.Abs(horizontal) == 1 && Mathf.Abs(vertical) == 1) // Check for diagonal movement for keyboard only
            {
                horizontal *= 0.7f;
                vertical *= 0.7f;
            }

            rigid_body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }catch(MissingReferenceException) { }
    }
}
