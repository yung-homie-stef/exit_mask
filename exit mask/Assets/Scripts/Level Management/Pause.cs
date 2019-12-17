using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public bool isMuted = false;
    public static bool isPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                AudioListener.pause = false;
            }
            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                AudioListener.pause = true;
            }
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

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void BackToMainMenu()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Scenes/First Release Scenes/Start");
        Time.timeScale = 1.0f;
        isPaused = false;
        audioManager.instance.StopAllSounds();
    }

    public void Quit()
    {
        Application.Quit();
    }


  public void TriggerMute()
  {
      isMuted = !isMuted;
  }

}
