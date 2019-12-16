using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMusicLevel(float sliderValue)
    {
        mixer.SetFloat("musicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXLevel(float sliderValue)
    {
        mixer.SetFloat("sfxVolume", Mathf.Log10(sliderValue) * 20);
    }
}
