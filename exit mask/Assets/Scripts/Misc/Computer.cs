using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private bool hackingAllowed = false;
    private Animator _animator;
    private BoxCollider _collider;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        _animator = Player.GetComponent<Animator>();
        _collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hackingAllowed && Input.GetKeyDown(KeyCode.E)) // when the player is in the collision box and presses E they hack the computer
            Hack();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            hackingAllowed = true;
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            hackingAllowed = false;
        }
    }

    void Hack()
    {
        _animator.SetBool("can_hack", true);
        Destroy(_collider); // this ensures that the player cannot hack the same computer 5 times and exit the maze very easily. 

        //TODO: call decrement function of door 
    }
}
