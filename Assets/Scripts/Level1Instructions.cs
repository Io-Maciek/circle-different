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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void _close_instructions()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _ability.enabled = true;
        _pause.enabled = true;
        Destroy(gameObject);
    }
}
