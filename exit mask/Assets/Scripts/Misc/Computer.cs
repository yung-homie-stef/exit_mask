using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private bool hackingAllowed = false;
    private Animator _animator;
    private BoxCollider _collider;
    private IEnumerator hackCoroutine;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        _animator = Player.GetComponent<Animator>();
        _collider = gameObject.GetComponent<BoxCollider>();
        hackCoroutine = StopHacking(1); // this variable represents a 1 second delay between allowing the player to hack/not hack
    }

    // Update is called once per frame
    void Update()
    {
        if (hackingAllowed && Input.GetKeyDown(KeyCode.E))
          Hack();  // when the player is in the collision box and presses E they hack the computer
          
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
            hackingAllowed = false;
    }

    void Hack()
    {
        _animator.SetBool("can_hack", true);
         // this ensures that the player cannot hack the same computer 5 times and exit the maze very easily.
         if (_collider.enabled == true)
        {
            _collider.isTrigger = false;
            _collider.enabled = false;
        }
        StartCoroutine(hackCoroutine); // call this coroutine once the player has hacked the computer

        //TODO: call decrement function of door 
    }

    IEnumerator StopHacking(int waitTime)
    {
        yield return new WaitForSeconds(waitTime); // wait for the alotted time, set the hack flag to false and disable this script
        _animator.SetBool("can_hack", false);
        this.enabled = false;
    }
}
