﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deepMachine : MonoBehaviour
{
    private BoxCollider _collider;
    private bool unlockingAllowed = false;
    private IEnumerator prisonCoroutine;
    private Transform newRespawnPosition;
    private bool canIncrement = true;
    private bool isDead = false;
    private float judicatorRepositioningTimer = 3.0f;
    private NavMeshAgent _agent;
    private Judicator _judicator;

    public GameObject Judicator;
    public GameObject Player;

    public GameObject[] prisonBars;
    public GameObject[] prisonGates;
    public GameObject flyScreen;
    public Transform judicatorTransform;


    // Start is called before the first frame update
    void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        prisonCoroutine = DestroyPrisonBars(3.0f);
        _judicator = Judicator.GetComponent<Judicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(unlockingAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Unlock();
        }

        if (isDead)
            judicatorRepositioningTimer -= Time.deltaTime;

        if (judicatorRepositioningTimer <= 0)
        {


            judicatorRepositioningTimer = 3.0f;
            isDead = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            unlockingAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        unlockingAllowed = false;   
    }

    private void Unlock()
    {
        canIncrement = true;

        

        // activate the chasing capabilities of the judicator
        _judicator.isFollowing = true;
        Judicator.GetComponent<Animator>().SetBool("is_following", true);

        //activate fly screens
        flyScreen.SetActive(true);

        #region Respawning
        // set the respawn position to the position of the player when they unlock a Judicator
        newRespawnPosition = Player.transform;
        Player.GetComponent<Death>().playerRespawnPoint.position = newRespawnPosition.position;
        Player.GetComponent<objectiveBasedRespawning_2>().machinesList.Add(this.gameObject);
        #endregion

        #region Prison
        // get animator of the bars and play unlocking animation
        for (int i = 0; i < prisonBars.Length; i++)
        {
            if (prisonBars[i].GetComponent<Animator>().GetBool("is_unlocked") == false)
            {
                prisonBars[i].GetComponent<Animator>().SetBool("is_unlocked", true);
                prisonBars[i].GetComponent<Animator>().SetBool("is_locked", false);
            }
        }

        // get animator of the bars and play locking animation
        for (int i =0; i < prisonGates.Length; i++)
        {
            prisonGates[i].SetActive(true);
        }

        this.enabled = false;
        #endregion

        audioManager.instance.Play("heart_machine");
    }

    private IEnumerator DestroyPrisonBars(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < prisonBars.Length; i++)
        {
            prisonBars[i].SetActive(false);
        }
    }

    public void ResetJudicatorStatus()
    {

        // get animator of the bars and play locking animation
        for (int i = 0; i < prisonBars.Length; i++)
        {
            prisonBars[i].GetComponent<Animator>().SetBool("is_locked", true);
            prisonBars[i].GetComponent<Animator>().SetBool("is_unlocked", false);
        }

        // get animator of the bars and play locking animation
        for (int i = 0; i < prisonGates.Length; i++)
        {
            prisonGates[i].SetActive(false);
        }

        // put the judicator back in the cage and turn off the fly screen
        _judicator.isFollowing = false;
        Judicator.GetComponent<Animator>().SetBool("is_following", false);


        isDead = true;

        flyScreen.SetActive(false);
        this.enabled = true;

        if (canIncrement == true)
        {
            canIncrement = false;
        }
    }
}
