using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
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
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        gameObject.GetComponent<CursorUnlocker>().enabled = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
        gameObject.GetComponent<CursorUnlocker>().enabled = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Debug.Log("BYE");
        Application.Quit();
    }

    
}
