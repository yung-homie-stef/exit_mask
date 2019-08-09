using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private Animator _animator;
    private bool openAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()  // only when the player is in the door collider and pressing 'E' can the door open
    {
        if (openAllowed && Input.GetKeyDown(KeyCode.E))
            OpenDoor();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            openAllowed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            openAllowed = false;
        }
    }

    private void OpenDoor()
    {
        _animator.SetBool("open_door", true); // play the door opening animation
    }



}
