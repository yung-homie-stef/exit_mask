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

        if (GetComponent<Animator>().GetBool("is_chasing") == true)
        {
            if (distance < maxDistance)
            {
                Vector3 towardsPlayer = transform.position - Player.transform.position;
                Vector3 newPosition = transform.position - towardsPlayer;
                _agent.speed = 5.0f;
                _agent.SetDestination(newPosition);
            }
            else if (distance > maxDistance)
            {
                _agent.speed = 0.5f;
            }
        }
        
    }
}
