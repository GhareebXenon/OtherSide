using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aud;

namespace Aud.SFX
{
    public class Sfx : MonoBehaviour
    {
        public SoundCollection[] soundFX;
        public void PlayShootSFX()
        {
            if (Input.GetButtonDown("Fire1"))
                soundFX[0].audioCollection[0].audioSource.Play();   
        }
    }
}
