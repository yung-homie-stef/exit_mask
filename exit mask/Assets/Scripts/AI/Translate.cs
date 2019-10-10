using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float length = 1;
    public Vector3 direction = Vector3.forward;
    public Transform first;
    public Transform second;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        first.position = this.transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        second.position = this.transform.position;
        second.position = first.position + direction * (Mathf.Sin(Time.time * speed) * length);
        this.transform.position = second.position;
    }
}
