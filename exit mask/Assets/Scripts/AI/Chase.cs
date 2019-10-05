using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject Player;
    public float maxDistance = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        // TO-DO: change this state to is_alerted
        if (GetComponent<Animator>().GetBool("is_aware") == true)
        {
            if (distance < maxDistance)
            {
                GetComponent<Animator>().SetBool("is_chasing", true);
                Vector3 towardsPlayer = transform.position - Player.transform.position;
                Vector3 newPosition = transform.position - towardsPlayer;
                _agent.speed = 5.0f;
                _agent.SetDestination(newPosition);
                // TO-DO: Change animator state to is_chasing HERE
            }
            else if (distance > maxDistance)
            {
                _agent.speed = 0.5f;
                GetComponent<Animator>().SetBool("is_chasing", false);
            }
        }
        
    }
}
