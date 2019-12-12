using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private NavMeshAgent _agent;
    public bool isStopped = true;
    private float stoppedTimer = 4.0f;

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

        // if the wheelcast raycast has been hit AND you are too close to a cowled begin chase
        if (GetComponent<Animator>().GetBool("is_aware") == true)
        {
            if (isStopped == true)
            {
                _agent.isStopped = true;
                stoppedTimer -= Time.deltaTime;


                if (stoppedTimer <= 0)
                {
                    _agent.isStopped = false;
                    isStopped = false;
                    stoppedTimer = 4.0f;
                    
                }
            }

            if (isStopped == false)
            {
                if (distance < maxDistance)
                {
                    GetComponent<Animator>().SetBool("is_chasing", true);
                    FindObjectOfType<audioManager>().Play("cowled_screaming");
                    Vector3 towardsPlayer = transform.position - Player.transform.position;
                    Vector3 newPosition = transform.position - towardsPlayer;
                    _agent.speed = 5.0f;
                    _agent.SetDestination(newPosition);
                    gameObject.GetComponent<AudioSource>().enabled = false;
                    
                }

                // if you get far enough stop chasing
                else if (distance > maxDistance)
                {
                    _agent.speed = 0.5f;
                    GetComponent<Animator>().SetBool("is_chasing", false);
                    gameObject.GetComponent<AudioSource>().enabled = true;
                }
            }
        }
        
    }
}
