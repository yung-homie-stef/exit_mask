﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class objectiveBasedRespawning : MonoBehaviour
{
    private GameObject Player;
    private unnamedIncubatorObjective _objective;

    public List<GameObject> machinesList = new List<GameObject>();
    public GameObject firstSpawn;

    // Start is called before the first frame update
    void Start()
    {
        machinesList.Add(firstSpawn);
        Player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Death>().deathTimerStarted == true)
        { 
            // to ensure this only happens once at least one transfusion machine is active
            if (machinesList.Count > 1)
            {
                machinesList[machinesList.Count - 1].GetComponent<unnamedIncubatorObjective>().ResetJudicatorStatus();

             
            }

                
        }
    }
}
