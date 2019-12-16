﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastMenu : MonoBehaviour
{
    public static bool isOver = false;

    public void GoBackToMainMenu()
    {
        isOver = true;
        SceneManager.LoadScene("Scenes/First Release Scenes/Start");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}