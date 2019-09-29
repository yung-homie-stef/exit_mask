using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;
    public float rotSpeed;
    public bool rotateClockwise;

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotSpeed; 
        Rotate();
        transform.LookAt(centerPoint); // always be looking at the centerpoint
    }

    void Rotate()
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
    }
}
