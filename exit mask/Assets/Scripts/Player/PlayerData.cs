using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData 
{
    public float[] position;
    public int currentScene;

    public PlayerData (characterController charController)
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        position = new float[3];
        position[0] = charController.transform.position.x;
        position[1] = charController.transform.position.y;
        position[2] = charController.transform.position.z;
    }

}
