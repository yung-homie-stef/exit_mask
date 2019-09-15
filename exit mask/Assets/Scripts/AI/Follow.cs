using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Player;

    float chaseSpeed;
    float maxDistance;
    float minDistance;

    // Update is called once per frame

    private void Start()
    {
        chaseSpeed = 3.0f;
        minDistance = 10.0f;
    }

    void Update()
    {
        //transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= minDistance)
        {

            transform.position += transform.forward * chaseSpeed * Time.deltaTime;
        }
    }
}
