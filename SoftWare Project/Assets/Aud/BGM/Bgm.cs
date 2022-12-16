using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Aud;
public class Bgm : MonoBehaviour
{
    [SerializeField] string nameOfScene;
    private void Awake()
    {
        CheckBGMPlaying();
    }

    private void Update()
    {
        ChangeMusicOnPlay();
    }

    public void CheckBGMPlaying()
    {
        GameObject[] bgmObjects = GameObject.FindGameObjectsWithTag("BGM");
        if (bgmObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeMusicOnPlay()
    {
        Scene sceneName = SceneManager.GetSceneByName(nameOfScene);
        if (sceneName.name == nameOfScene)
        {
            Destroy(this.gameObject);
        }
    }
}
