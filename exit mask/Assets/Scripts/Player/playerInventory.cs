using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
   public bool hasCutter = false;
   private Animator _animator; 

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

     if (hasCutter == true)
        {
            _animator.SetBool("is_armed", true);
        }
           
    }

    public void SetBoxCutterStatus(bool stat)
    {
        hasCutter = stat;
    }


}
