using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator _animator;
    private float deathTime;
    private bool deathTimerStarted;

    public Transform playerRespawnPoint;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        deathTime = 3.0f;
        deathTimerStarted = false;
    }

    private void Update()
    {
        // counts down whenever player dies
        if (deathTimerStarted == true)
        {
            deathTime -= Time.deltaTime;
        }
        if (deathTime < 0)
            PlayerRespawn();
    }

    public void Kill()
    {
        // play animation of player falling over
        // restrict them from moving themselves or camera
        _animator.SetBool("is_dead", true);
        gameObject.GetComponent<characterController>().enabled = false;
        playerCamera.GetComponent<camMouseLook>().enabled = false;
        deathTimerStarted = true; // start death timer, making the player respawn after it has reached 0
        
   
    }

    public void PlayerRespawn()
    {
        // bring the player back to life
        // respawn them at the start of the level, enable controls again, and reset the death timer
        _animator.SetBool("is_dead", false);
        gameObject.GetComponent<characterController>().enabled = true;
        playerCamera.GetComponent<camMouseLook>().enabled = true;
        gameObject.transform.position = playerRespawnPoint.position;
        deathTime = 3.0f;
        deathTimerStarted = false;


    }
}
