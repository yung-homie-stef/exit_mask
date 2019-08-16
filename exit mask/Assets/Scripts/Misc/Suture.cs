using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suture : MonoBehaviour
{
    private GameObject _fleshWall;
    private BoxCollider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        _fleshWall = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Destroy(gameObject);
            _fleshWall.GetComponent<fleshWall>().RipFlesh();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
