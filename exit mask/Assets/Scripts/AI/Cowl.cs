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
    private Vector3 newPos;

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
            newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            _agent.SetDestination(newPos);
            _timer = 0;
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