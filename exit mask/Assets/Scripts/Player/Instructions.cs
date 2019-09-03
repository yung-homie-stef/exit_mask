using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text levelText;
    public string currentInstructionText;

    private Animator _animator;

    private void Start()
    {
        _animator = levelText.GetComponent<Animator>();
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

    }

}
