using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Player;

    float chaseSpeed;
    float minDistance;

    private Animator _animator;

    // Update is called once per frame

    private void Start()
    {
        chaseSpeed = 3.0f;
        minDistance = 10.0f;

        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //transform.LookAt(Player);

        if (_animator.GetBool("is_chasing") == true)
        {

            transform.position += transform.forward * chaseSpeed * Time.deltaTime;
        }

     
    }
}
