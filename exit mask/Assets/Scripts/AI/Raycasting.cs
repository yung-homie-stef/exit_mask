using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private Animator _animator;

    public Color rayColor;
    public GameObject[] cowls;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        _ray = new Ray(transform.position, transform.forward * 100);
        Debug.DrawRay(transform.position, transform.forward * 100, rayColor);

        if (Physics.Raycast(transform.position, transform.forward * 100, out _hit, Mathf.Infinity)) // occurs when the raycast is hit
        {
            foreach (GameObject cowl in cowls)
            {
                //TODO: Set chase behaviour to true
                cowl.GetComponent<Animator>().SetBool("is_chasing", true);
            }

            _animator.SetBool("is_alerted", true);
            Debug.Log("ray has hit");
        }
    }

}
