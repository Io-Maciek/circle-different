using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutUI : MonoBehaviour
{
    public GameObject PreviousScreen;


    public Button BtnBackToPreviousScreen;
    // Start is called before the first frame update
    void Start()
    {
        BtnBackToPreviousScreen.onClick.AddListener(_to_previous);
    }

    private void _to_previous()
    {
        PreviousScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
