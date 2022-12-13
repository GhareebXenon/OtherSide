using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aud
{
    [Serializable]
    public class SoundSource
    {
        public string name;
        public AudioSource audioSource;
    }
    [Serializable]
    public class SoundCollection
    {
        public string name;
        public SoundSource[] audioCollection;
    }
}