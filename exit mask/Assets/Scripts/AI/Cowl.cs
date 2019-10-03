using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Cowl : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;
    public bool isAlerted;

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
        isAlerted = false;
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

        if (isAlerted == true)
        {
            // TO-DO:
            // animator setbool isalerted to true
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