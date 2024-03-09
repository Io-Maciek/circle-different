using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckPoint : MonoBehaviour
{
    public int CheckPointNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent != null)
        {
            var trigger = other.transform.parent.GetComponentInParent<PlayerCheckpoints>();
            if (trigger != null)
            {
                trigger.CheckPointTriggerEnter(CheckPointNumber);
            }
        }
    }
}
