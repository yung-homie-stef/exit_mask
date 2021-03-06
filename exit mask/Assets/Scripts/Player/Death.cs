﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.IO;

public class Death : MonoBehaviour
{
    private Animator _animator;
    private Animator _fadeAnimator;
    private float deathTime;
    private GameObject[] cowls;
    private GameObject[] wheels;

    public Transform playerRespawnPoint;
    public Camera playerCamera;
    public GameObject deathFader;
    public float killVolume;
    public bool deathTimerStarted;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _fadeAnimator = deathFader.GetComponent<Animator>();
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

    private void OnTriggerEnter(Collider other)
    {
        // when the player walks through a new respawn point, call a function that changes the current respawn point to this one instead
        if (other.tag == "Respawn_Point")
        {
            BoxCollider boxcol = other.GetComponent<BoxCollider>();
            // disable the trigger so that this respawn point can never be reactivated
            boxcol.enabled = false; 

            Transform newRespawnTransform = other.transform;
            UpdatePlayerRespawnPoint(newRespawnTransform);

            Save();

        }
            
    }

    public void Kill()
    {
        // play animation of player falling over
        // restrict them from moving themselves or camera
        _animator.SetBool("is_dead", true);
        _fadeAnimator.SetBool("has_died", true);
        

        gameObject.GetComponent<characterController>().enabled = false;
        playerCamera.GetComponent<CameraController>().is_dead = true;

            ResetAIBehaviour();

        // start death timer, making the player respawn after it has reached 0
        deathTimerStarted = true;

       audioManager.instance.Play("death");

    }


    public void PlayerRespawn()
    {
        // bring the player back to life
        // respawn them at the start of the level, enable controls again, and reset the death timer
        _animator.SetBool("is_dead", false);
        _fadeAnimator.SetBool("has_died", false);

        gameObject.GetComponent<characterController>().enabled = true;
        gameObject.transform.position = playerRespawnPoint.position;
        gameObject.transform.rotation = playerRespawnPoint.rotation;

        playerCamera.GetComponent<CameraController>().is_dead = false;

        deathTime = 3.0f;
        deathTimerStarted = false;
    }

    private void UpdatePlayerRespawnPoint(Transform tf)
    {
        playerRespawnPoint.position = tf.position;

    }

    private void ResetAIBehaviour()
    {
        cowls = GameObject.FindGameObjectsWithTag("Cowl_Enemy");
        wheels = GameObject.FindGameObjectsWithTag("Wheel_Enemy");

        foreach (GameObject cowl in cowls)
        {
            // reset all flags in cowled enemies animator
            cowl.GetComponent<Animator>().SetBool("is_aware", false);
            cowl.GetComponent<Animator>().SetBool("is_chasing", false);
            cowl.GetComponent<Chase>().isStopped = true;
            cowl.GetComponent<NavMeshAgent>().speed = 0.5f;

        }

        foreach (GameObject wheel in wheels)
        {
            wheel.GetComponent<Wheels>().rayHasHit = false;
            wheel.GetComponent<Wheels>().SetAlertToFalse();

        }
    }

    public void Save()
    {
        SaveObject saveObject = new SaveObject
        {
            position = this.gameObject.transform.position,
            currentSceneName = SceneManager.GetActiveScene().name,
            currentScene = SceneManager.GetActiveScene(),


        };

        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
        Debug.Log("Saved");
    }
}
