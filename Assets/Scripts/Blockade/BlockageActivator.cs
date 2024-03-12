using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BlockageActivator : MonoBehaviour
{
    public BlockageScript Blockage;
    public bool IsActive = false;

    public uint HowManyTimesActivated = 0;
    //public bool _player_activated = false;

    float _object_scaler = 0.9f;
    Vector3 _default_scale_collider;
    Vector3 _default_scale;
    BoxCollider2D _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _default_scale_collider = _boxCollider.size;
        _boxCollider.size = _default_scale_collider * _object_scaler;
        _default_scale = transform.localScale;
    }


    /*    private void OnTriggerEnter2D(Collider2D collision)
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
                transform.localScale = _default_scale * _object_scaler;
                _boxCollider.size = _default_scale_collider;
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
                transform.localScale = _default_scale;
                _boxCollider.size = _default_scale_collider * _object_scaler;
                Blockage.Close();
            }

        }*/


    public void Enter()
    {
        HowManyTimesActivated++;
        if (!IsActive)
        {
            IsActive = true;
            transform.localScale = _default_scale * _object_scaler;
            _boxCollider.size = _default_scale_collider;
            Blockage.Open();
        }

    }

    public void Exit()
    {
        HowManyTimesActivated--;

        if (IsActive && HowManyTimesActivated == 0)
        {
            IsActive = false;
            transform.localScale = _default_scale;
            _boxCollider.size = _default_scale_collider * _object_scaler;
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
