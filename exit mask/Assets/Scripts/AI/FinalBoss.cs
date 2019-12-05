using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    private Animator _animator;
    private IEnumerator centipedeCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        centipedeCoroutine = Kill(0.25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            StartCoroutine(centipedeCoroutine);
        }
    }

     IEnumerator Kill(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("is_killed", true);
        //play death sound 
    }
}
