using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intrusiveImageDeactivator : MonoBehaviour
{
    private bool timersAreSet;
    private bool activeTimerSet;
    private bool disabledTimerSet;
    // images can be on screen from 3 to 6 seconds, and have a downtime of 7-12 seconds

    private float imageActiveTimer;
    private float imageDisabledTimer;


    // Start is called before the first frame update
    void Start()
    {
        timersAreSet = false;
        activeTimerSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timersAreSet == false)
        {
            timersAreSet = true;
            imageActiveTimer = GenerateRandomTimer(3,6);
            imageDisabledTimer = GenerateRandomTimer(5, 10);
            activeTimerSet = true;
        }

        if (activeTimerSet == true)
        {
            imageActiveTimer -= Time.deltaTime;
            Debug.Log(imageActiveTimer);

            if (imageActiveTimer < 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                activeTimerSet = false;
                disabledTimerSet = true;
            }
        }
        else if (activeTimerSet == false && disabledTimerSet == true)
        {
            imageDisabledTimer -= Time.deltaTime;
            Debug.Log(imageDisabledTimer);
            
            if (imageDisabledTimer < 0)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                timersAreSet = false;
            }
            
        }


    }

    private float GenerateRandomTimer(float min, float max)
    {
        return Random.Range(min, max);
       
    }

       

}
