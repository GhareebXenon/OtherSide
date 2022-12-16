using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVol : MonoBehaviour
{
    [SerializeField] Slider sliderVol;

    public void SetVolLevel(float sliderVol)
    {
        AudioListener.volume = sliderVol;
    }

    private void Update()
    {
        SetVolLevel(sliderVol.value);
    }

    private void Awake() {
        sliderVol.value = AudioListener.volume;
    }
}
