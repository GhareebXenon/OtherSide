using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{

    private bool isPaused;
    void Start()
    {
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
        if (isPaused && GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponentInChildren<AudioSource>().Pause();
        }
        else
            GetComponentInChildren<AudioSource>().Play();
    }
}
