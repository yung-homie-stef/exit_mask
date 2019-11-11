using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool clockwise;
    private int dir;

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
            dir = 1;
        else
            dir = -1;

        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, dir * 90 * Time.deltaTime, 0);
    }
}
