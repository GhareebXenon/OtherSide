using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aud;
public class Bgm : MonoBehaviour
{

    public SoundCollection[] bgm;
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "your collider name")
            if (!bgm[0].audioCollection[0].audioSource.isPlaying)
                if (!bgm[0].audioCollection[0].audioSource.loop)
                    bgm[0].audioCollection[0].audioSource.Play();
                else if (other.gameObject.name == "your collider name")
                {
                    if (!bgm[0].audioCollection[1].audioSource.isPlaying)
                        if (!bgm[0].audioCollection[0].audioSource.loop)
                            bgm[0].audioCollection[1].audioSource.Play();
                }

                else
                {
                    Debug.Log("OnCollisionEnter2D");
                }
    }
}
