using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour
{
    public Button BtnExit;
    // Start is called before the first frame update
    void Start()
    {
        BtnExit.onClick.AddListener(_exit);
    }

    private void _exit()
    {
        SaveNumber.Delete();
        SceneManager.LoadSceneAsync(0);
    }
}
