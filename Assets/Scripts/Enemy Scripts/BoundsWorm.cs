using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsWorm : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision worm with: " + collision.collider.name);
        if (collision.collider.CompareTag("Bounds"))
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
