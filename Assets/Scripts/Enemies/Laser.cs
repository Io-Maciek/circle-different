using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject player;
    BecomeSquareAbility player_ability;

    void Start()
    {
        player_ability = player.GetComponentInParent<BecomeSquareAbility>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.gameObject == player && player_ability.IsCircle)
        {
            player.transform.GetComponentInParent<ActivateDeath>().Die();
        }
    }
}
