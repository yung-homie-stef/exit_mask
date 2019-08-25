using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pendra : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform destinationPoint;

    private Animator _animator;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();

        _agent = GetComponent<NavMeshAgent>();
        _agent.autoBraking = false;
        _agent.destination = destinationPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            gameObject.transform.position = spawnPoint.position;
        }
    }
}
