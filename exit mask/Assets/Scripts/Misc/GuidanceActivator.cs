using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceActivator : MonoBehaviour
{
    public GameObject guidanceMachine;

    private void OnTriggerEnter(Collider other)
    {
        guidanceMachine.SetActive(true);
    }
}
