using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Needle : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private Animator _animator;
    private IEnumerator transitionCoroutine;
    public string scenename;

    public GameObject levelFader;

    // Start is called before the first frame update
    void Start()
    {
        _animator = levelFader.GetComponent<Animator>();
    }

    private void Update()
    {
        if (pickUpAllowed == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            _animator.SetBool("level_completed", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            pickUpAllowed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            pickUpAllowed = false;
    }

    private IEnumerator loadLevel(float waitTime)
    {
        Debug.Log("loading");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scenename);

    }
}
