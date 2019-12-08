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

    private int minDisable;
    private int maxDisable;
    private int pcCount;

    public GameObject Exit;


    // Start is called before the first frame update
    void Start()
    {
        timersAreSet = false;
        activeTimerSet = false;

        pcCount = Exit.GetComponent<mazeExit>().GetPCCount();

    }

    // Update is called once per frame
    void Update()
    {

        // switch statement
        // the more computers the player activates, the smaller the disabled gif window is 
        switch (pcCount)
        {
            case 4:
                minDisable = 5;
                maxDisable = 10;
                break;
            case 3:
                minDisable = 5;
                maxDisable = 8;
                break;
            case 2:
                minDisable = 4;
                maxDisable = 6;
                break;
            case 1:
                minDisable = 3;
                maxDisable = 6;
                break;
            case 0:
                minDisable = 2;
                maxDisable = 4;
                break;
        }



        if (timersAreSet == false)  // when the image is activated, create a timer for its time activated and deactivated
        {
            timersAreSet = true;
            imageActiveTimer = GenerateRandomTimer(3,6);
            imageDisabledTimer = GenerateRandomTimer(minDisable, maxDisable);
            transform.GetChild(0).gameObject.transform.position = GenerateRandomCanvasPos(100, Screen.width - 100, 100, Screen.height - 100); // generate a random position

            activeTimerSet = true;
        }

        if (activeTimerSet == true) // when the image is active, start counting down till you hit 0. at 0, disable the gif
        {
            imageActiveTimer -= Time.deltaTime;

            if (imageActiveTimer < 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                activeTimerSet = false;
                disabledTimerSet = true;
            }
        }
        else if (activeTimerSet == false && disabledTimerSet == true) // when disabled, start coutning down until it is active again
        {
            imageDisabledTimer -= Time.deltaTime;
            
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

    private Vector3 GenerateRandomCanvasPos(float minX, float maxX, float minY, float maxY)
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        return new Vector3(x, y, 1);

        
    }

       

}
