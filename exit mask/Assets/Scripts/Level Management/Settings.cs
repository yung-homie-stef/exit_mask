using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject settingsMenu;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("music_volume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("sfx_volume", volume);
    }
}
