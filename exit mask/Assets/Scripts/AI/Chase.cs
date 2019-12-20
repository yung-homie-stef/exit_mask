using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public bool isStopped = true;
    public GameObject Player;
    public float maxDistance = 5.0f;

    private NavMeshAgent _agent;
    private float stoppedTimer = 4.0f;
    private float distance;
    private Animator _animator;
    private AudioSource _source;


    // Start is called before the first frame update
    void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _animator = gameObject.GetComponent<Animator>();
        _source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position, Player.transform.position);

        // if the wheelcast raycast has been hit AND you are too close to a cowled begin chase
        if (_animator.GetBool("is_aware") == true)
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
                    _animator.SetBool("is_chasing", true);
                    Vector3 towardsPlayer = transform.position - Player.transform.position;
                    Vector3 newPosition = transform.position - towardsPlayer;
                    _agent.speed = 5.0f;
                    _agent.SetDestination(newPosition);
                    _source.enabled = false;

                }

                // if you get far enough stop chasing
                else if (distance > maxDistance)
                {
                    audioManager.instance.Play("cowled_screaming");
                    _agent.speed = 0.5f;
                    _animator.SetBool("is_chasing", false);
                    _source.enabled = true;
                }
            }
        }
        
    }
}
