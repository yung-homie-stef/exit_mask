using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffinMover : MonoBehaviour
{
    public GameObject Coffin;
    public Transform nextPoint;

    private BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // changes coffin position to a position that is now further from the player, leading them
            Coffin.transform.position = nextPoint.transform.position;
            // makes sure the coffin cannot be triggered again and have its position brough back
            _collider.enabled = false;
        }
    }
}
