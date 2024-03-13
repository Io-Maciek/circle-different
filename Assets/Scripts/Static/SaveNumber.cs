using Assets.Scripts.Game;
using UnityEngine.SceneManagement;

public static class SaveNumber
{
    public static Game _GAME_SAVE = null;

    public static void UpdateToNextScene(uint sceneBuildIndexNumber, int checkPointNumber = 0, bool shouldLoadScene = false)
    {
        if (_GAME_SAVE == null)
            return;

        _GAME_SAVE.SceneNumber = sceneBuildIndexNumber;
        _GAME_SAVE.CheckPointNumber = checkPointNumber;
        _GAME_SAVE.Save();

        if (shouldLoadScene)
        {
            SceneManager.LoadSceneAsync((int)sceneBuildIndexNumber);
        }
    }

    public static void Delete()
    {
        if (_GAME_SAVE == null)
            return;

        _GAME_SAVE.Delete();
        _GAME_SAVE = null;
    }
}
