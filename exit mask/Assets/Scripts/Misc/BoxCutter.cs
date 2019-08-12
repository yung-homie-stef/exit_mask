﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxCutter : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private Animator _animator;
    private playerInventory _inventory;

    public GameObject equippableBoxCutter;
    public GameObject Player;
    public Animator textAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _inventory = Player.GetComponent<playerInventory>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)) // when the player is in the collision box and presses E pick up box cutter
           PickUp();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            pickUpAllowed = true;
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            pickUpAllowed = false;
        }
    }

    void PickUp()
    {
        textAnimator.SetBool("picked_up", true);
        Destroy(gameObject);
        equippableBoxCutter.SetActive(true);
        _inventory.SetBoxCutterStatus(true);

    }

    
}
