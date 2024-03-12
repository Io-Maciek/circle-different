using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressShiftInstruction : MonoBehaviour
{
    public bool WasActivated = false;
    public GameObject Text;

    public BecomeSquareAbility _ability;
    public GamePause _pauser;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerObjectController>() != null)
        {
            if (!WasActivated)
            {
                Text.SetActive(true);
                _ability.enabled = false;
                _pauser.enabled = false;
                Time.timeScale = 0.0f;
                WasActivated = true;
            }
        }
    }

    private void Update()
    {
        if (WasActivated)
        {
            if (Input.GetAxisRaw("Fire3") != 0.0f)
            {
                Text.SetActive(false);
                _ability.enabled = true;
                _pauser.enabled = true;
                Time.timeScale = 1.0f;
            }
        }   
    }
}
