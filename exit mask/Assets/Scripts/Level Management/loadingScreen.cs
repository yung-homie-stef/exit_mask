﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingScreen : MonoBehaviour
{
    public GameObject image;
    
    private Animator _animator;
    private IEnumerator loadCoroutine;
    private IEnumerator fadeCoroutine;

    public float fadeTime;
    public float loadTime;

    // Start is called before the first frame update
    void Start()
    {
        _animator = image.GetComponent<Animator>();
    }

    private void Update()
    {
        loadCoroutine = loadNextLevel(loadTime);
        fadeCoroutine = fadeChapterScreen(fadeTime);
        StartCoroutine(fadeCoroutine);
        StartCoroutine(loadCoroutine);
    }

    private IEnumerator loadNextLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator fadeChapterScreen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("level_completed", true);
    }

}