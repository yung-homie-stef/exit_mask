using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text levelText;
    public string currentInstructionText;

    private Animator _animator;
    private IEnumerator disableCoroutine;

    private void Start()
    {
        _animator = levelText.GetComponent<Animator>();
        disableCoroutine = DisableTextTemporarily(6.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeText(currentInstructionText);
        }
    }

    public void ChangeText(string txt)
    {
        levelText.text = currentInstructionText;
        _animator.SetBool("has_changed", true);
        StartCoroutine(disableCoroutine);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator DisableTextTemporarily(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("has_changed", false);
        Destroy(gameObject);
    }

}
