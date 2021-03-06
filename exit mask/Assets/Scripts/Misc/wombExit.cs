﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wombExit : MonoBehaviour
{
    public static int bloodCount;
    public GameObject[] wombSprites;
    public GameObject exitTipTrigger;
    public GameObject coffin;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        bloodCount = 3;
        _animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bloodCount == 0)
        {
            _animator.SetBool("open_door", true);
            exitTipTrigger.SetActive(true);
            coffin.SetActive(true);
        }
    }

    public void DecrementBloodCount()
    {
        bloodCount--;
        ActivateGIF(bloodCount);
    }

    public void IncrementBloodCount()
    {
        bloodCount+=1;
        DeactivateGIF(bloodCount-1);
        Debug.Log(bloodCount);
    }

    void ActivateGIF(int index)
    {
        wombSprites[index].SetActive(true);
    }

    void DeactivateGIF(int index)
    {
        wombSprites[index].SetActive(false);
    }

    public int GetBloodCount()
    {
        return bloodCount;
    }
}
