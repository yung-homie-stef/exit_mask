using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderEnabler : MonoBehaviour
{
    public GameObject enabledObject;
    private BoxCollider _boxCollider;

    void Start()
    {
        _boxCollider = enabledObject.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player")
         {
            _boxCollider.enabled = true;
         }
    }
    

}
