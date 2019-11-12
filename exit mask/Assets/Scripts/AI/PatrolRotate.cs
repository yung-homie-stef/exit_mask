using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRotate : MonoBehaviour
{
    public float dir;
    public float currentAngle;
    public float smallerAngle;
    public float largerAngle;
    public float speed;

    private void Start()
    {
        dir = -1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (dir == 1.0f)
        {
            currentAngle += dir * Time.deltaTime * speed;
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, currentAngle, gameObject.transform.rotation.z);
            if (currentAngle > largerAngle)
            {
                dir = -1.0f;
            }
        }
        if (dir == -1.0f)
        {
            currentAngle += dir * Time.deltaTime * speed;
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, currentAngle, gameObject.transform.rotation.z);
            if (currentAngle < smallerAngle)
            {
                dir = 1.0f;
            }
        }
    }

}
