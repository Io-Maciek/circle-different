using Assets.Scripts.Game;
using UnityEngine.SceneManagement;

public static class SaveNumber
{
    public static Game _GAME_SAVE = null;

    public static void UpdateToNextScene(uint sceneBuildIndexNumber, int checkPointNumber = 0, bool shouldLoadScene = false)
    {
        _GAME_SAVE.SceneNumber = sceneBuildIndexNumber;
        _GAME_SAVE.CheckPointNumber = checkPointNumber;

        if (shouldLoadScene)
        {
            SceneManager.LoadSceneAsync((int)sceneBuildIndexNumber);
        }
    }
}
