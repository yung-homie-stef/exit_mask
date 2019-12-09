﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject loadButton;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (SaveSystem.hasSaveFile == true)
        {
            loadButton.SetActive(true);
        }
        else
            loadButton.SetActive(false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoBackToMainMenu()
    {
       
        SceneManager.LoadScene("Scenes/First Release Scenes/Start");
        
    }

    public void GoBackToMainMenuAfterEnd()
    {
        FindObjectOfType<audioManager>().Stop("credits_theme");
        SaveSystem.hasSaveFile = false;
        SceneManager.LoadScene("Scenes/First Release Scenes/Start");
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadData();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        SceneManager.LoadScene(data.currentScene);
    }
}
