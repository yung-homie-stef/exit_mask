using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_2 : MonoBehaviour
{
    public GameObject image;
    public GameObject whiteCanvas;
    bool levelTimerSet;
    float levelTimer;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = image.GetComponent<Animator>();
        levelTimerSet = false;
        levelTimer = 6.0f;

    }

    private void Update()
    {
        if (levelTimerSet == true)
            levelTimer -= Time.deltaTime;

        if (levelTimer <= 0)
        {
            LoadNextLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("level_completed", true);
            levelTimerSet = true;
            whiteCanvas.SetActive(true);

        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
