using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public bool isMuted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
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

    public void TriggerMute()
    {
        isMuted = !isMuted;
    }

    public void GoBack()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

}
