using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMover : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.position = rb.position + new Vector3(0, 0, 0.1f);
    }
}
