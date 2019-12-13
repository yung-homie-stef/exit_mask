using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guidance : MonoBehaviour
{
    public Image hintImage;
    public GameObject Player;
    public GameObject Wires;
    public float minimumDistance;

    private bool activatingAllowed;
    private Color tempColor;

    private float distanceBetween;
    private Transform newRespawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        tempColor = hintImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = Vector3.Distance(Player.transform.position, gameObject.transform.position);

        if (distanceBetween < minimumDistance)
        {
            tempColor.a = Mathf.InverseLerp(minimumDistance, 0.0f, distanceBetween);
            hintImage.color = tempColor;
        }

        if (activatingAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Wires.SetActive(true);
            Activate();
        }
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
        Destroy(hintImage);
        FindObjectOfType<audioManager>().Play("heart_machine");
        newRespawnPosition = Player.transform;
        Player.GetComponent<Death>().playerRespawnPoint.position = newRespawnPosition.position;

        
    }
}
