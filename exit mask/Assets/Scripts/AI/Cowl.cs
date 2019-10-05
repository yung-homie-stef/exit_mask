using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Cowl : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    private Transform _target;
    private NavMeshAgent _agent;
    private float _timer;
    private Animator _animator;

    // Use this for initialization
    void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        _timer = wanderTimer;
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            _agent.SetDestination(newPos);
            _timer = 0;
        }

        // cowled enemies pause briefly when they become enraged 
        // so their navmesh stops temporarily
        if (_animator.GetBool("is_aware") == true)
        {

        }



    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

}