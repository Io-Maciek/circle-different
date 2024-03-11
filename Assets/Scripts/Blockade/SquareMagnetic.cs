using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMagnetic : MonoBehaviour
{
    public BecomeSquareAbility player_ability;
    public GameObject player;

    public float DistanceToStartMagnetic = 5.0f;
    public float forceFactor = 5.0f;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(player.transform.position, transform.position) <= DistanceToStartMagnetic && !player_ability.IsCircle)
        {
            Debug.Log("START MAGNETIC");
            rb.AddForce((player.transform.position - transform.position) * forceFactor);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
