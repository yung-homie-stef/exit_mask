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
        canvasNum = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // TO-DO: get rid of this debug code and instead set the alerted bool to true 
        // from another script
        if (Input.GetKey(KeyCode.K))
        {
            SelectRandomCanvas(0, images.Length);
            hasBeenAlerted = true;
        }

        if (hasBeenAlerted == true)
        {
            images[canvasNum].SetActive(true);
            alertTimer -= Time.deltaTime;

                if (alertTimer <= 0)
            {
                images[canvasNum].SetActive(false);
                this.enabled = false;
            }
        }
    }

    public void SelectRandomCanvas(int min, int max)
    {
        canvasNum = Random.Range(min, max);

    }
}
