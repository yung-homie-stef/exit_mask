using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponLogic : MonoBehaviour
{
    public GameObject Player;

    private Animator _animator;
    private BoxCollider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _animator = Player.GetComponent<Animator>();
        _collider = gameObject.GetComponent<BoxCollider>();
        _collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // only activate the collider when the player is actually stabbing. 
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("stab"))
        {
            _collider.enabled = true;
        }
        else
        {
            _collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 
        if (other.gameObject.tag == "Fume_Enemy")
        {
            Debug.Log("you are hitting a fume");
        }

        //TODO: Add actual damage logic
    }
}
