using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunEnemy : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void SetStun()
    {
        // when this method is called, stun the Fume enemy
        // TODO: add coroutines to delay stun until player's wrist is done being slit
        _animator.SetBool("is_stunned", true);
      
    }

    public void BreakStun()
    {
        _animator.SetBool("is_stunned", false);
        Debug.Log("booyah");
    }

  

}
