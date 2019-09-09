using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class importantCollectible : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private bool transitionStarted = false;
    private float transitionTimer = 8.0f;
    private Animator _animator;
    private Renderer _renderer;

    public GameObject levelFader;
    public Animator textAnimator;

    private IEnumerator fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        _animator = levelFader.GetComponent<Animator>();
        _renderer = GetComponent<Renderer>();
        fadeScreen = BeginFadingScreen(3.0f);
    }
    
    private void Update()
    {
        Debug.Log(transitionTimer);

        if (pickUpAllowed == true && Input.GetKeyDown(KeyCode.E))
        {
            transitionStarted = true;
            FindObjectOfType<audioManager>().Play("Pickup");
            StartCoroutine(fadeScreen);
        }


        if (transitionStarted == true)
        {
            textAnimator.SetBool("picked_up", true);
            transitionTimer -= Time.deltaTime;
            _renderer.enabled = false;
            
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator BeginFadingScreen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("level_completed", true);
    }
}
