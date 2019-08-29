using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullEntrance : MonoBehaviour
{
    public GameObject entranceSkull;
    public GameObject mazeDoor;
    private IEnumerator doorCoroutine;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = entranceSkull.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("is_triggered", true);
            doorCoroutine = ActivateDoor(3.8f);
            StartCoroutine(doorCoroutine);
        }
    }

    private IEnumerator ActivateDoor(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mazeDoor.SetActive(true);
    }
}
