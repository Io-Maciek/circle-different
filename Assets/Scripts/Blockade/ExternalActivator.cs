using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalActivator : MonoBehaviour
{
    //private bool _is_on = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        var _activator = collision.GetComponent<BlockageActivator>();
        if( _activator != null /*&& _is_on*/)
        {
           //_is_on = false;
            _activator.Exit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var _activator = collision.GetComponent<BlockageActivator>();
        if (_activator != null /*&& !_is_on*/)
        {
            //_is_on = true;
            _activator.Enter();
        }
    }
}
