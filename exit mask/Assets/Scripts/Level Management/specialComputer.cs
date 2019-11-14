using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class specialComputer : MonoBehaviour
{
    private bool hackingAllowed = false;
    private bool transitionStarted = false;
    private float transitionTimer = 8.0f;
    private Animator _playerAnimator;
    private Animator _fadeAnimator;

    public GameObject levelFader;
    public Animator textAnimator1;
    public Animator textAnimator2;
    public GameObject Player;
    public GameObject terminalScreens;

    private IEnumerator fadeScreen;
    private IEnumerator hackCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = Player.GetComponent<Animator>();
        _fadeAnimator = levelFader.GetComponent<Animator>();
        fadeScreen = BeginFadingScreen(3.0f);
        hackCoroutine = StopHacking(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (hackingAllowed && Input.GetKeyDown(KeyCode.E))
        {
            _playerAnimator.SetBool("can_hack", true);
            FindObjectOfType<audioManager>().Play("Typing");
            StartCoroutine(hackCoroutine);
            transitionStarted = true;
        }

        if (transitionStarted == true)
        {
            textAnimator1.SetBool("picked_up", true);
            textAnimator2.SetBool("picked_up", true);
            transitionTimer -= Time.deltaTime;

        }

        if (transitionTimer <= 0)
            LoadSpecifiedLevel();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            hackingAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        hackingAllowed = false;
    }

    void LoadSpecifiedLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator BeginFadingScreen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _fadeAnimator.SetBool("level_completed", true);
    }


    IEnumerator StopHacking(int waitTime)
    {
        yield return new WaitForSeconds(waitTime); // wait for the alotted time, set the hack flag to false and disable this script
        _playerAnimator.SetBool("can_hack", false);
        terminalScreens.SetActive(true);
        FindObjectOfType<audioManager>().Play("Computer_Boot_Up");
    }
}
