﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wombExit : MonoBehaviour
{
    public static int bloodCount;
    public GameObject[] wombSprites;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        bloodCount = 4;
        _animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bloodCount == 0)
        {
            _animator.SetBool("can_exit", true);
            for (int i=0; i<wombSprites.Length; i++ )
            {
                wombSprites[i].SetActive(false);
            }
        }
    }

    public void DecrementBloodCount()
    {
        bloodCount--;
        ActivateGIF(bloodCount);
        Debug.Log(bloodCount);
    }

    void ActivateGIF(int index)
    {
        wombSprites[index].SetActive(true);
    }

    public int GetBloodCount()
    {
        return bloodCount;
    }
}