using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class importantCollectible : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private bool transitionStarted = false;
    private float transitionTimer = 6.0f;
    private Animator _animator;
    private Renderer _renderer;

    public GameObject levelFader;
    public int index;
    public Animator textAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = levelFader.GetComponent<Animator>();
        _renderer = GetComponent<Renderer>();
    }
    
    private void Update()
    {
        Debug.Log(transitionTimer);

        if (pickUpAllowed == true && Input.GetKeyDown(KeyCode.E))
        {
            transitionStarted = true;
            
        }


        if (transitionStarted == true)
        {
            textAnimator.SetBool("picked_up", true);
            transitionTimer -= Time.deltaTime;
            _animator.SetBool("level_completed", true);
            _renderer.enabled = false;
            FindObjectOfType<audioManager>().Play("Pickup");
        }

        if (transitionTimer <= 0)
            LoadSpecifiedLevel();

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

    void LoadSpecifiedLevel()
    {
        SceneManager.LoadScene(index);
    }
}
