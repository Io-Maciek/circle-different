using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Instructions : MonoBehaviour
{
    public Button BtnExit;
    public BecomeSquareAbility _ability;
    public GamePause _pause;

    private void Start()
    {
        BtnExit.onClick.AddListener(_close_instructions);
        Time.timeScale = 0.0f;
        _ability.enabled = false;
        _pause.enabled = false;
    }

    private void _close_instructions()
    {
        Time.timeScale = 1.0f;
        _ability.enabled = true;
        _pause.enabled = true;
        Destroy(gameObject);
    }
}
