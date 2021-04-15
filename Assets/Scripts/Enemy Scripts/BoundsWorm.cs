using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsWorm : MonoBehaviour
{
    public LayerMask playerLayerMask;
    public GameObject front;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10, playerLayerMask))
        {
            front.GetComponent<WormPart>().Boost();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision worm with: " + collision.collider.name);
        if (collision.collider.CompareTag("Bounds"))
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
