using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eventCollectible : MonoBehaviour
{
   public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {

        }
    }


}
