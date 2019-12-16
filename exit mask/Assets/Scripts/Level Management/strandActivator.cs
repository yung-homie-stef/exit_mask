using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strandActivator : MonoBehaviour
{
    public GameObject baby;
    public GameObject[] DNA;

    private void OnTriggerEnter(Collider other)
    {
        baby.SetActive(true);
        
        for (int i=0; i < DNA.Length; i++)
        {
            DNA[i].SetActive(true);
        }
    }


}
