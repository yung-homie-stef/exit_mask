using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unnamedIncubatorObjective : MonoBehaviour
{
    private Animator _unlockerAnimator;
    private BoxCollider _collider;
    private bool unlockingAllowed = false;

    public GameObject Judicator;
    public GameObject[] prisonBars;
    public GameObject[] prisonGates;
    public GameObject Exit;

    // Start is called before the first frame update
    void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(unlockingAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Unlock();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            unlockingAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        unlockingAllowed = false;   
    }

    private void Unlock()
    {
        // activate the chasing capabilities of the judicator
        Judicator.GetComponent<Judicator>().isFollowing = true;

        // get animator of the bars and play unlocking animation

        Exit.GetComponent<wombExit>().DecrementBloodCount();

        for (int i =0; i < prisonGates.Length; i++)
        {
            prisonGates[i].SetActive(true);
        }

        this.enabled = false;
    }
}
