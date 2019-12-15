using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Wheels : MonoBehaviour
{
    private Animator _animator;
    private Animator _cowlAnimator;
    private IEnumerator unAlertCoroutine;
    private float staticTimer;
    private bool timerStarted;
    private LineRenderer line;
    private characterController _controller;
    private RaycastHit _hit;

    public float rayDist = 25;
    public bool rayHasHit;
    public GameObject[] cowls;
    public GameObject staticCanvas;
    public GameObject player;
    public Transform headPosition;



    // Start is called before the first frame update
    void Start()
    {
        timerStarted = false;
        staticTimer = 4.0f;
        rayHasHit = false;
        _animator = gameObject.GetComponent<Animator>();
        _controller = player.GetComponent<characterController>();

        line = GetComponent<LineRenderer>();
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.startColor = Color.white;
        line.endColor = Color.white;
        line.numCapVertices = 6;

        if(!headPosition)
        {
            Debug.Log(transform.name + " No head position defined.");
            Debug.Break();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Ray _ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayDist, Color.green);

        if (Physics.Raycast(_ray, out _hit, rayDist))
        {
            if (_hit.collider.tag == "Player" && _animator.GetBool("is_alerted") == false && rayHasHit == false)
            {

                Debug.Log("ray has hit");
                
                
                foreach (GameObject cowl in cowls)
                {
                    cowl.GetComponent<Animator>().SetBool("is_aware", true);
                }

                _animator.SetBool("is_alerted", true);
                rayHasHit = true;
                audioManager.instance.Play("alert_static");
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
            _controller.speed = 2;

            if (staticTimer <= 0)
            {
                timerStarted = false;
                staticCanvas.SetActive(false);
                staticTimer = 4.0f;
                _controller.speed = 5;
            }
        }

        line.SetPosition(0, headPosition.position + transform.forward * 0.5f);
        line.SetPosition(1, (headPosition.position + transform.forward * rayDist));
    }

    public void SetAlertToFalse()
    {
        _animator.SetBool("is_alerted", false);

    }


}
