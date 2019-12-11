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

        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            loadButton.SetActive(true);
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

    public void GoBackToMainMenuAfterEnd()
    {
        SceneManager.LoadScene("Scenes/First Release Scenes/Start");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string savestring = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(savestring);


            SceneManager.LoadScene(saveObject.currentSceneName);

        }
    }
        
    

}
