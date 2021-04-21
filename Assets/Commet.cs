using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

}
