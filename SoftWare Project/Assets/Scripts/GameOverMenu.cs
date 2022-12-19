using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        Character.OnPlayerDeath += EnableGameOverMenu;
    }
    private void OnDisable()
    {
        Character.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);


    }
}
