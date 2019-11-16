using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    private Animator _animator;
    private IEnumerator unAlertCoroutine;
    private float staticTimer;
    private bool timerStarted;

    public float rayDist = 25;
    public bool rayHasHit;
    public GameObject[] cowls;
    public GameObject staticCanvas;

    // Start is called before the first frame update
    void Start()
    {
        timerStarted = false;
        staticTimer = 4.0f;
        rayHasHit = false;
        _animator = gameObject.GetComponent<Animator>();
        unAlertCoroutine = SetAlertToFalse(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayDist, Color.green);

        if (Physics.Raycast(_ray, out _hit, 100, 1 << 11)) // 11th element being the player layer
        {
            if (_hit.collider.tag == "Player" && _animator.GetBool("is_alerted") == false && rayHasHit == false)
            {

                Debug.Log("ray has hit");
                
                foreach (GameObject cowl in cowls)
                {
                    cowl.GetComponent<Animator>().SetBool("is_aware", true);
                }

                StartCoroutine(unAlertCoroutine);
                _animator.SetBool("is_alerted", true);
                rayHasHit = true;
            }
        }

        if (rayHasHit == true) // replace this with raycast logic
        {
            timerStarted = true;
            rayHasHit = false;
        }

        if (timerStarted == true)
        {
            staticTimer -= Time.deltaTime;
            staticCanvas.SetActive(true);

            if (staticTimer <= 0)
            {
                timerStarted = false;
                staticCanvas.SetActive(false);
                staticTimer = 4.0f;
            }
        }


    }

    private IEnumerator SetAlertToFalse(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("is_alerted", false);

    }


}
