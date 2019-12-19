using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Judicator : MonoBehaviour
{
    private Vector3 newPosition;
    private NavMeshAgent _agent;
    private Vector3 towardsPlayer;

    public bool isFollowing;
    public GameObject Player;
    public Transform judicatorTransform;

    private void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        isFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing == true) // begin following the player once their door has been unlocked, triggering this flag
        {
             towardsPlayer = transform.position - Player.transform.position;
             newPosition = transform.position - towardsPlayer;
            _agent.SetDestination(newPosition);
        }
    }

    public void Respawn()
    {
        this.gameObject.transform.position = judicatorTransform.position;
    }

}
