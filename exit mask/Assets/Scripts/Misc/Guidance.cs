using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guidance : MonoBehaviour
{
    public GameObject hintImage;
    public GameObject Player;
    public GameObject Wires;
    public float minimumDistance;
        
    private Color imageColour;
    private bool activatingAllowed;
    private bool activateImage;
    private float distanceBetween;

    // Start is called before the first frame update
    void Start()
    {
        imageColour = hintImage.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = Vector3.Distance(Player.transform.position, gameObject.transform.position);

        if (distanceBetween < minimumDistance)
        {
            hintImage.SetActive(true);
        }
        else
            hintImage.SetActive(false);

        if (activatingAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Activate();
        }

        if (activateImage)
            hintImage.SetActive(true);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            activatingAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        activatingAllowed = false;
    }

    private void Activate()
    {
        Wires.SetActive(true);
        Destroy(hintImage);
    }
}
