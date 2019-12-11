using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public bool isMuted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }

        if (isMuted == true)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("music_volume", volume);
        Debug.Log(volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("sfx_volume", volume);
    }

    public void TriggerMute()
    {
        isMuted = !isMuted;
    }

}
