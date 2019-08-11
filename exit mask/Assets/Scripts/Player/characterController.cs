using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpImpulse = 20.0f;
    private Rigidbody rb;
    private Animator _animator; 
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKeyDown("space"))
           rb.AddForce(new Vector3(0, jumpImpulse, 0), ForceMode.Impulse);

        // left click to attack
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("is_attacking", true);
        }
        else
        {
            _animator.SetBool("is_attacking", false);
        }

        // right click to self-harm
        if (Input.GetMouseButtonDown(1))
        {
            _animator.SetBool("is_attacking_self", true);
        }
        else
        {
            _animator.SetBool("is_attacking_self", false);
        }
    }
}
