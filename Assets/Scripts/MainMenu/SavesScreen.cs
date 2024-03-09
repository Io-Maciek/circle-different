using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavesScreen : MonoBehaviour
{
    public GameObject PreviousScreen;
    public Button BtnBackOut;

    public Text TitleText;

    public LoadingSaves saveLoader;
    public List<SaveFileUI> saveFileObjectsUI;


    // Start is called before the first frame update
    void Start()
    {
        BtnBackOut.onClick.AddListener(_back_to_menu);
    }

    private void _back_to_menu()
    {
        PreviousScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loadSave">True for loading existing saves. False to start new game on a save file.</param>
    public void Set(bool loadSave)
    {
        if (loadSave)
        {
            TitleText.text = "Load game";

            for (int i = 0; i < saveFileObjectsUI.Count; i++)
            {
                if (saveLoader.SavedGames[i] == null)
                {
                    saveFileObjectsUI[i].Empty(loadSave);
                    saveFileObjectsUI[i].GetComponent<Button>().interactable = false;
                }
                else
                {
                    saveFileObjectsUI[i].Set(saveLoader.SavedGames[i], loadSave);
                    saveFileObjectsUI[i].GetComponent<Button>().interactable = true;
                }
            }
        }
        else
        {
            TitleText.text = "Start new game";

            for (int i = 0; i < saveFileObjectsUI.Count; i++)
            {
                
                if (saveLoader.SavedGames[i] == null)
                {
                    saveFileObjectsUI[i].Empty(loadSave);
                }
                else
                {
                    saveFileObjectsUI[i].Set(saveLoader.SavedGames[i], loadSave);
                }
                saveFileObjectsUI[i].GetComponent<Button>().interactable = true;
            }
        }
    }


}
