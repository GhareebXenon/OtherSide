using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSoundDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
