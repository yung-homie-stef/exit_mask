﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed;
    //public float jumpImpulse;
    public GameObject selfHarmCanvas; // tv static display when player cuts themselves
    
    private GameObject[] fumes; // array filled by looking for every enemy with proper tag
    private Rigidbody rb;
    private Animator _animator;
    private float stabTime;
    private bool stabTimerStarted;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();

        _animator.SetBool("can_attack_self", true);


       stabTime = 0.9f;
        stabTimerStarted = false;

    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        // this timer update check gives a 1 second delay between the start of the self-harm animation
        // so that enemies are stunned right when the knife comes in contact with the player's wrist
        if (stabTimerStarted == true)
        {
            stabTime -= Time.deltaTime;
            _animator.SetBool("can_attack_self", false);
        }

        if (stabTime < 0)
        {
            StunEnemies();   // stun enemies when the wrist is slit, along with reset the timer
            stabTime = 0.9f;
            stabTimerStarted = false;

            _animator.SetBool("is_attacking_self", false);

            FindObjectOfType<audioManager>().Play("Self_Harm_Static");

            selfHarmCanvas.SetActive(true); // once the self harm stun on the enemies is finished, disable the canvas overlay
            
        }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        //if (Input.GetKeyDown("space"))
        //   rb.AddForce(new Vector3(0, jumpImpulse, 0), ForceMode.Impulse);

        // left click to attack
        if (Input.GetMouseButtonDown(0))
        {
                _animator.SetBool("is_attacking", true);
        }
        else
        {
            _animator.SetBool("is_attacking", false);
        }

        // right click to self-harm
        if (Input.GetMouseButtonDown(1))
        {
            if (_animator.GetBool("can_attack_self") == true)
            {
                _animator.SetBool("is_attacking_self", true);
                stabTimerStarted = true;
            }
        }

        if (gameObject.transform.position.y < gameObject.GetComponent<Death>().killVolume)
        {
            gameObject.GetComponent<Death>().Kill();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Fume_Enemy")
        {
            // the player technically only collides with fume enemies if they are not stunned
            // otherwise they wont get damaged
            if (collision.gameObject.GetComponent<Animator>().GetBool("is_stunned") == false)
            {
                // die if you touch an enemy
                gameObject.GetComponent<Death>().Kill();
            }
        }

        if (collision.gameObject.tag == "Pendra_Enemy")
        {
            // otherwise if the player collides with a centipede just kill them instantly
            // as they do not have any stun status to check for
            gameObject.GetComponent<Death>().Kill();
        }
        
    }

    void StunEnemies()
    {
        // look for every Fume enemy and fill an array with them
            fumes = GameObject.FindGameObjectsWithTag("Fume_Enemy");

        foreach(GameObject fume in fumes)
        {
            // for each Fume in this scene, call its stun method
            fume.GetComponent<Fume>().setStun(true);
            

        }
    }
}
