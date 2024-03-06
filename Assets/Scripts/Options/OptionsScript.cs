using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public GameObject MenuScreen;

    public Button BtnGoBack;

    void Start()
    {
        BtnGoBack.onClick.AddListener(_close_options);
    }

    private void _close_options()
    {
        if(MenuScreen != null)
        {
            MenuScreen.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
