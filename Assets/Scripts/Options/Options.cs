using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Options
{
    const string _FULLSCREEN = "full_screen_player_prefs";
    const string _RESOLUTION = "resolution_player_prefs";

    public bool IsFullScreen { 
        get 
        {
            return PlayerPrefs.GetInt(_FULLSCREEN, 1) == 1;
        } 
        set
        {
            PlayerPrefs.SetInt(_FULLSCREEN, value?1:0);
        }
    }

    public string Resolution {
        get
        {
            return PlayerPrefs.GetString(_RESOLUTION, ScreenResolution.GetResolutions().First());
        }
        set
        {
            PlayerPrefs.SetString(_RESOLUTION, value);
        }
    }


    public void Apply()
    {
        FullScreenMode fullscreen_mode;
        var resolutions = ScreenResolution.ResolutionFromString(Resolution);

        if (IsFullScreen)
        {
            fullscreen_mode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            fullscreen_mode = FullScreenMode.Windowed;
        }

        Screen.SetResolution(resolutions.Item1, resolutions.Item2, fullscreen_mode);
    }
}

public static class ScreenResolution
{
    public static IEnumerable<string> GetResolutions()
    {
        return Screen.resolutions
            .OrderByDescending(r => r.width)
            .ThenByDescending(r => r.height)
            .Select(_res => $"{_res.width}x{_res.height}")
            .Distinct();
    }

    public static IEnumerable<RefreshRate> GetFramerate(string resolution)
    {
        var reso = ResolutionFromString(resolution);
        return Screen.resolutions
            .Where(r=>r.width==reso.Item1 && r.height==reso.Item2)
            .OrderByDescending(r => r.refreshRateRatio)
            .Distinct()
            .Select(r=>r.refreshRateRatio);
    }

    public static (int, int) ResolutionFromString(string resolution) 
    {
        string[] _res = resolution.Split('x');

        return (int.Parse(_res[0]), int.Parse(_res[1]));
    }

}
