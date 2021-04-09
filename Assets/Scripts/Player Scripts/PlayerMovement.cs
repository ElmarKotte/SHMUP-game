using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movement;
    public float acceleration;
    public Rigidbody rb;
    public float speed; //Speed van de player
    public float maxSpeed; //Speed van de player
    public float rotateSpeed;

    private Vector3 currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.eulerAngles;
        speed = 10;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            Acceleration();
        }
        else
        {
            Deceleration();
        }
        rotation();
    }
    private void FixedUpdate()
    {
        rb.velocity = movement * speed * Time.deltaTime + new Vector3(0, 0, 5f);
    }
    public void Acceleration()
    {
        speed = speed + acceleration;
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
    }
    public void Deceleration()
    {
        speed = 0;
    }

    public void rotation()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(70, 90, 180);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(70, -90, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(110, 0, 90);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(70, 0, 90);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(90, 0, 90);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);

        }
    }
}
