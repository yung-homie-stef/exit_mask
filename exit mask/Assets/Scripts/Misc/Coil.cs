using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour
{
    public GameObject coilSkull;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = coilSkull.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        coilSkull.SetActive(true);
        _animator.SetBool("is_triggered", true);
       audioManager.instance.Play("skull_drone");
    }

}
