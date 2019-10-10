﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    private Animator _animator;
    private IEnumerator unAlertCoroutine;
    private bool rayHasHit;

    public GameObject[] cowls;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        unAlertCoroutine = SetAlertToFalse(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 25, Color.green);

        if (Physics.Raycast(_ray, out _hit, 100))
        {
            if (_hit.collider.tag == "Player" && _animator.GetBool("is_alerted") == false && rayHasHit == false)
            {
                
                Debug.Log("ray has hit");
                
                foreach (GameObject cowl in cowls)
                {
                    // replace this with an is_aware animation instead
                    cowl.GetComponent<Animator>().SetBool("is_aware", true);
                }

                StartCoroutine(unAlertCoroutine);
                _animator.SetBool("is_alerted", true);
                rayHasHit = true;
            }
        }



        if (Input.GetKeyDown(KeyCode.K)) // replace this with raycast logic
        {
            gameObject.GetComponent<alertImages>().SelectRandomCanvas(0, 4);
        }
    }

    private IEnumerator SetAlertToFalse(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("is_alerted", false);

    }


}