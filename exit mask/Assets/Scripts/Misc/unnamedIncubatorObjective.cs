using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unnamedIncubatorObjective : MonoBehaviour
{
    private BoxCollider _collider;
    private bool unlockingAllowed = false;
    private IEnumerator prisonCoroutine;
    private Transform newRespawnPosition;

    public GameObject Judicator;
    public GameObject Player;

    public GameObject[] prisonBars;
    public GameObject[] prisonGates;
    public GameObject Exit;
    public GameObject flyScreen;

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

        //activate fly screens
        flyScreen.SetActive(true);

        Exit.GetComponent<wombExit>().DecrementBloodCount();

        #region Respawning
        // set the respawn position to the position of the player when they unlock a Judicator
        Player.GetComponent<Death>().playerRespawnPoint.position = Player.transform.position;
        int firstEmpty = System.Array.IndexOf(Player.GetComponent<objectiveBasedRespawning>().unlockedTranfusionMachines, null);
        Debug.Log(firstEmpty);
        Player.GetComponent<objectiveBasedRespawning>().unlockedTranfusionMachines[firstEmpty] = this.gameObject;
        #endregion

        #region Prison
        // get animator of the bars and play unlocking animation
        for (int i = 0; i < prisonBars.Length; i++)
        {
            prisonBars[i].GetComponent<Animator>().SetBool("is_unlocked", true);
        }
        // get animator of the bars and play locking animation
        for (int i =0; i < prisonGates.Length; i++)
        {
            prisonGates[i].SetActive(true);
        }


        StartCoroutine(prisonCoroutine);
        this.enabled = false;
        #endregion
    }

    private IEnumerator DestroyPrisonBars(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < prisonBars.Length; i++)
        {
            prisonBars[i].SetActive(false);
        }
    }
}
