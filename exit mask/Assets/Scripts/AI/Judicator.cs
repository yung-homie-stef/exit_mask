using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Judicator : MonoBehaviour
{
    private NavMeshAgent _agent;
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
            Vector3 towardsPlayer = transform.position - Player.transform.position;
            Vector3 newPosition = transform.position - towardsPlayer;
            _agent.SetDestination(newPosition);
        }
    }

}
