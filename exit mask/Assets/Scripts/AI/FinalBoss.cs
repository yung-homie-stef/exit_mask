using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    public Animator textAnimator;
    public GameObject levelFader;

    private Animator _animator;
    private IEnumerator centipedeCoroutine;
    private IEnumerator fadeScreen;
    private bool timerRunning;
    private float timer = 14.0f;
    private Animator _fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _fadeAnimator = levelFader.GetComponent<Animator>();
        centipedeCoroutine = Kill(0.25f);
        fadeScreen = BeginFadingScreen(10.0f);
        timerRunning = false;

        FindObjectOfType<audioManager>().Play("theme_reversed");
        //FindObjectOfType<audioManager>().Stop("theme_3");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            StartCoroutine(centipedeCoroutine);
        }
    }

    private IEnumerator BeginFadingScreen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _fadeAnimator.SetBool("level_completed", true);
    }

    private void Update()
    {
        if (timerRunning == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            LoadLevel();
        }
    }

    IEnumerator Kill(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("is_killed", true);
        textAnimator.SetBool("picked_up", true);
        timerRunning = true;
        StartCoroutine(fadeScreen);

        //play death sound 
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
