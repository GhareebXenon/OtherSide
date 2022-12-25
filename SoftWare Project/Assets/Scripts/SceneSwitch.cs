using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void openScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
