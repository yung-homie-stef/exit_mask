using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertImages : MonoBehaviour
{
    private int canvasNum;

    public bool hasBeenAlerted;
    public float alertTimer;
    public GameObject[] images;

    // Start is called before the first frame update
    void Start()
    {
        hasBeenAlerted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenAlerted == true)
        {
            alertTimer -= Time.deltaTime;

                if (alertTimer <= 0) // after a short delay disable the image on the screen
            {
                images[canvasNum].SetActive(false);
                Destroy(this);
            }
        }
    }

    public void SelectRandomCanvas(int min, int max)
    {
        canvasNum = Random.Range(min, max); // generate a random int between 0 and 2, then activate the image in the array with that index value
        Debug.Log(canvasNum);
        images[canvasNum].SetActive(true);
        hasBeenAlerted = true; // sets off the timer in update
    }

}
