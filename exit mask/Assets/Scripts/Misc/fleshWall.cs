using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleshWall : MonoBehaviour
{
    private Animator _animator;
    private BoxCollider _collider;


    // Start is called before the first frame update
    void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        _animator = gameObject.GetComponent<Animator>();
    }

    public void RipFlesh()
    {
        // _animator.SetBool("rip_flesh", true);
        _collider.enabled = false;
    }

}
