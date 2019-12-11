using System.Collections;
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
        SceneManager.LoadScene("Scenes/First Release Scenes/Start");
    }

}
