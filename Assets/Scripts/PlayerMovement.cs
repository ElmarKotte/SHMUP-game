using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movement;
    public float acceleration;
    public Rigidbody rb;
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            Acceleration();
        }
        else
        {
            Deceleration();
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.position = rb.position + new Vector3(0, 0, 0.1f);
    }
    public void Acceleration()
    {
        speed = speed + 0.1f;
        if(speed >= 10)
        {
            speed = 10;
        }
    }
    public void Deceleration()
    {
        speed = 0;
    }
}
