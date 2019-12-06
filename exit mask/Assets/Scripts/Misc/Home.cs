using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public Animator textAnimator;

    private void OnTriggerEnter(Collider other)
    {
        textAnimator.SetBool("is_home", true);
    }
}
