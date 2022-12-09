using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHoverAudio : MonoBehaviour
{

    public GameObject HoverAudioObj;
    public void DropHoverAudio()
    {
        Instantiate(HoverAudioObj, transform.position, transform.rotation);
    }
}
