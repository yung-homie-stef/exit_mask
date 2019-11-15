using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unnamedIncubatorObjective : MonoBehaviour
{
    private BoxCollider _collider;
    private bool unlockingAllowed = false;
    private IEnumerator prisonCoroutine;

    public GameObject Judicator;
    public GameObject[] prisonBars;
    public GameObject[] prisonGates;
    public GameObject Exit;

    // Start is called before the first frame update
    void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        prisonCoroutine = DestroyPrisonBars(3.0f);
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
        Judicator.GetComponent<Animator>().SetBool("is_following", true);

        // get animator of the bars and play unlocking animation

        Exit.GetComponent<wombExit>().DecrementBloodCount();

        for (int i =0; i < prisonGates.Length; i++)
        {
            prisonGates[i].SetActive(true);
        }

        for (int i = 0; i < prisonBars.Length; i++)
        {
            prisonBars[i].GetComponent<Animator>().SetBool("is_unlocked", true);
        }

        StartCoroutine(prisonCoroutine);
        this.enabled = false;
    }

    private IEnumerator DestroyPrisonBars(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < prisonBars.Length; i++)
        {
            Destroy(prisonBars[i]);
        }
    }
}
