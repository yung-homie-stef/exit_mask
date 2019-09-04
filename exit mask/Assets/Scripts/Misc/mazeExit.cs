using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mazeExit : MonoBehaviour
{
    public static int pcCount;
    private Animator _animator;

    public GameObject[] intrusiveSprites;

    // Start is called before the first frame update
    void Start()
    {
        pcCount = 5;
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pcCount == 0)
        {
            // TODO: swap this destroy call out with setting a bool flag to open the exit door. 
            Destroy(gameObject);
        }
    }

    public void DecrementPCCount()
    {
        // every time a computer is hacked reduce this number. signifies one objective being cleared
        pcCount--;
        ActivateGIF(pcCount);
    }

    void ActivateGIF(int index)
    {
        intrusiveSprites[index].SetActive(true);
    }

    public int GetPCCount()
    {
        return pcCount;
    }
}
