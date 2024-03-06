using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public GameObject MenuScreen;

    public Button BtnGoBack;
    public Toggle ToggleFullScreen;
    public Dropdown DropdownResolution;

    Options _options = new Options();

    void Start()
    {
        BtnGoBack.onClick.AddListener(_close_options);
        ToggleFullScreen.onValueChanged.AddListener(_full_screen_changed);
        DropdownResolution.onValueChanged.AddListener(_resolution_changed);

        OptionsSetup();
    }

    private void _resolution_changed(int resolution_index)
    {
        Debug.Log(DropdownResolution.options[resolution_index].text);
        _options.Resolution = DropdownResolution.options[resolution_index].text;
    }

    private void _full_screen_changed(bool is_full_screen)
    {
        _options.IsFullScreen = is_full_screen;
    }

    void OptionsSetup()
    {
        ToggleFullScreen.isOn = _options.IsFullScreen;

        var resolutions = ScreenResolution.GetResolutions();
        DropdownResolution.options = resolutions.Select(resolution => new Dropdown.OptionData(resolution)).ToList();

        int index_of_resolution = 0;

        foreach (var resolution in resolutions)
        {
            if (resolution == _options.Resolution)
                break;
            index_of_resolution++;
        }

        DropdownResolution.value = index_of_resolution;
    }

    private void _close_options()
    {
        _options.Apply();
        if(MenuScreen != null)
        {
            MenuScreen.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
