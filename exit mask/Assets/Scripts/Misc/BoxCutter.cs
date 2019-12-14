using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxCutter : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private Animator _animator;
    private playerInventory _inventory;

    public GameObject equippableBoxCutter;
    public GameObject Player;

    public Animator textAnimator1;
    public Animator textAnimator2;


    public GameObject cutterTextTrigger;
    public GameObject[] screens;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _inventory = Player.GetComponent<playerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))   // when the player is in the collision box and presses E pick up box cutter
            PickUp();

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            pickUpAllowed = true;
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            pickUpAllowed = false;
        }
    }

    void PickUp()
    {

        for (int i=0; i < screens.Length; i++)
        {
            screens[i].SetActive(true);
        }

        textAnimator1.SetBool("picked_up", true);
        textAnimator2.SetBool("picked_up", true);
        Destroy(gameObject);
        equippableBoxCutter.SetActive(true);
        _inventory.SetBoxCutterStatus(true);
        cutterTextTrigger.SetActive(true);
        audioManager.instance.Play("pickup");


    }

}
