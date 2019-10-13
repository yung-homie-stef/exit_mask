using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text levelText;
    public string currentInstructionText;
    public GameObject textBG;

    private Animator _textAnimator;
    private Animator _bgAnimator;
    private IEnumerator disableCoroutine;

    private void Start()
    {
        _textAnimator = levelText.GetComponent<Animator>();
        _bgAnimator = textBG.GetComponent<Animator>();
        disableCoroutine = DisableTextTemporarily(12.0f);
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
        levelText.text = txt;
        _textAnimator.SetBool("has_changed", true);
        _bgAnimator.SetBool("has_changed", true);
        StartCoroutine(disableCoroutine);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator DisableTextTemporarily(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _textAnimator.SetBool("has_changed", false);
        _bgAnimator.SetBool("has_changed", false);
        Destroy(gameObject);
    }

}
