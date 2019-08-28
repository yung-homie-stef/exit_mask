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
        _collider.enabled = false;
        _animator.SetBool("is_cut", true);
        FindObjectOfType<audioManager>().Play("Flesh_Rip");
    }

}
