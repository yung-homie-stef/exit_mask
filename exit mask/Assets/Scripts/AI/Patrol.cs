using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int destinationPoint = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // by disabling auto-braking, the moving object does not ease in/out of patrol points
        // instead, the movement stays consistent
        agent.autoBraking = false;

        GoToNextPoint();
        
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        // sets the agent's destination to the destination array's current index value
        agent.destination = points[destinationPoint].position;

        // go to the next destination in the array
        // the modulo allows the array to cycle to the beginning if needed
        destinationPoint = (destinationPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }   
}
