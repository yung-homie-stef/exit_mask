using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = teleportTarget.transform.position;
    }

}
