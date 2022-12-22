using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{

    private bool isPaused;
    private AudioSource combatTheme;
    private void Awake()
    {
        combatTheme = GetComponentInChildren<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMusicOnPauseMenu();
        }
    }

    public void PauseMusicOnPauseMenu()
    {
        isPaused = !isPaused;
        if (isPaused && combatTheme.isPlaying)
            combatTheme.Pause();
        else
            combatTheme.UnPause();

    }
}
