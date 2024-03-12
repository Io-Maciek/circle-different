using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockageActivator : MonoBehaviour
{
    public BlockageScript Blockage;
    public bool IsActive = false;

    public uint HowManyTimesActivated = 0;
    public bool _player_activated = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckIfPlayer(collision))
        {
            _player_activated = true;
        }
        else
        {
            HowManyTimesActivated++;
        }

        if (!IsActive)
        {
            IsActive = true;
            Blockage.Open();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckIfPlayer(collision))
        {
            _player_activated = false;
        }
        else
        {
            HowManyTimesActivated--;
        }

        if(IsActive && HowManyTimesActivated == 0 && !_player_activated)
        {
            IsActive = false;
            Blockage.Close();
        }

    }


    bool CheckIfPlayer(Collider2D collision)
    {
        Debug.Log($"{collision.gameObject.name}\t{collision.transform.parent.gameObject.name}");
        if (collision.transform.parent == null)
        {
            return false;
        }
        return collision.transform.parent.gameObject.name == "PlayerObject";
    }
}
