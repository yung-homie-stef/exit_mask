using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fume : MonoBehaviour
{
    public Transform[] points;
    public GameObject selfHarmCanvas;
    public GameObject player;
    public GameObject intrusiveImageCanvas;

    private int destinationPoint = 0;
    private NavMeshAgent _agent;
    private Animator _animator;
    private bool isStun = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = gameObject.GetComponent<Animator>();

        // by disabling auto-braking, the moving object does not ease in/out of patrol points
        // instead, the movement stays consistent
        _agent.autoBraking = false;

        GoToNextPoint();
        
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        // sets the agent's destination to the destination array's current index value
        _agent.destination = points[destinationPoint].position;

        // go to the next destination in the array
        // the modulo allows the array to cycle to the beginning if needed
        destinationPoint = (destinationPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f && isStun == false)
        {
            GoToNextPoint();

        }
        if(isStun)
        {
            checkForStun();
        }
    }


    public void setStun(bool stunValue)
    {
        if(stunValue)
        {
            _animator.SetBool("is_stunned", true);

            isStun = true;
            _agent.isStopped = true;
            intrusiveImageCanvas.SetActive(false);
            gameObject.GetComponent<AudioSource>().enabled = false;

        }
        else if(!stunValue)
        {
            _animator.SetBool("is_stunned", false);

            isStun = false;
            _agent.isStopped = false;
            selfHarmCanvas.SetActive(false);
            player.GetComponent<Animator>().SetBool("can_attack_self", true);
            intrusiveImageCanvas.SetActive(true);
            gameObject.GetComponent<AudioSource>().enabled = true;

        }
    }

    private void checkForStun()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("stunned") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            setStun(false);
        }
    }

}
