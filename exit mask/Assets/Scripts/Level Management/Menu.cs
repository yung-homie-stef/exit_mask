using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{
    public GameObject loadButton;
    private GameObject player;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (File.Exists(Application.dataPath + "/save.txt") && LastMenu.isOver == false)
        {
            loadButton.SetActive(true);
        }
        else if (LastMenu.isOver == true)
        {
            loadButton.SetActive(false);
        }
            
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

    public void LoadGame()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string savestring = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(savestring);

            if (saveObject.currentSceneName == "Dream" || saveObject.currentSceneName == "Basement" ||
                saveObject.currentSceneName == "Maze" || saveObject.currentSceneName == "Hive" ||
                saveObject.currentSceneName == "Needle")
            {
                audioManager.instance.Play("theme");
            }

            else if (saveObject.currentSceneName == "Towers" || saveObject.currentSceneName == "Incubator" ||
                saveObject.currentSceneName == "Helix" || saveObject.currentSceneName == "Root")
            {
                audioManager.instance.Play("theme_2");
            }

            else if (saveObject.currentSceneName == "Dark" || saveObject.currentSceneName == "Coil")
            {
                audioManager.instance.Play("theme_3");
            }

            else if (saveObject.currentSceneName == "Home")
            {
                audioManager.instance.Play("theme_reversed");
            }

            SceneManager.LoadScene(saveObject.currentSceneName);

        }
    }
        
    

}
