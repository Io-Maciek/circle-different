using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeath : MonoBehaviour
{
    public GameObject DeathScreen;
    public GamePause gamePause;
    public GameObject abilityBar;

    GameObject _player;

    private void Start()
    {
        _player = GetComponent<camera_movement>().player;
    }

    public void Die()
    {
        gamePause.HidePauseMenu();
        gamePause.enabled = false;
        abilityBar.SetActive(false);

        Destroy(_player);
        DeathScreen.SetActive(true);
        Time.timeScale = 0.3f;
    }
}
