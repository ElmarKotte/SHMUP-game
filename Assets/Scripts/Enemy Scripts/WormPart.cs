using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormPart : MonoBehaviour
{
    public int MaxHealth;
    public int health;
    public LayerMask playerLayerMask;
    public GameObject front;
    public GameObject back;
    public GameObject hitExplosion;
    public GameObject explosion;

    public float minDistance = 0.25f;
    public float minSpeed = 1f;
    public float currentSpeed = 1f;
    public float boostMultiplier = 1.5f;
    public float speedLoss = 10f;
    public float rotationFrequency = 50f;
    public float rotationAmmount = 50f;

    public int healthPerPart;

    public int beginSize;

    public Transform wormSpawner;
    public GameObject headPrefab;
    public GameObject bodyPrefab;
    private float previousPerlin = 0;
    private float mapTime;
    private float distance;
    public bool isHead = false;
    public bool isBack = false;

    void Start()
    {
        health = MaxHealth;
        mapTime = Random.Range(0, 9999);
    }

    public void Rotate()
    {
        mapTime += Time.deltaTime * rotationFrequency;

        float currentPerlin = Mathf.PerlinNoise(mapTime, 0);
        float R = (currentPerlin - previousPerlin) * rotationAmmount;

        transform.Rotate(new Vector3(0, R, 0));
        previousPerlin = currentPerlin;
    }

    // Deze funcite beweegt alle body parts achter de gene voor zich aan 
    public void Move()
    {
        if (isHead)
        {
            transform.Translate(transform.forward * currentSpeed * Time.smoothDeltaTime, Space.World);
            Rotate();
        }
        else
        {
            distance = Vector3.Distance(front.transform.position, transform.position);
            Vector3 newPos = front.transform.position;
            newPos.y = transform.position.y;

            float T = Time.deltaTime * distance / minDistance * currentSpeed;

            if (T > 0.5f)
                T = 0.5f;

            transform.position = Vector3.Slerp(transform.position, newPos, T);
            transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, T);
        }

    }
    public void CheckHealth()
    {
        if (health <= 0)
        {
            if (!isHead)
            {
                front.GetComponent<WormPart>().isBack = true;
            }
            if (!isBack)
            {
                back.GetComponent<WormPart>().isHead = true;
            }
            GameObject exp = Instantiate(explosion);
            exp.transform.position = transform.position;
            GameObject cam = FindObjectOfType<Camera>().gameObject;
            StartCoroutine(cam.GetComponent<CameraShake>().Shake(0.75f, 5f));
            Destroy(gameObject);
        }
    }
    public void Boost()
    {
        currentSpeed = boostMultiplier * minSpeed;
    }

    void Update()
    {
        if (isHead)
        {
            currentSpeed -= speedLoss * Time.deltaTime;
            if (currentSpeed < minSpeed)
            {
                currentSpeed = minSpeed;
            }

            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10, playerLayerMask))
            {
                Boost();
            }
        }
        CheckHealth();
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            GameObject exp = Instantiate(hitExplosion);
            exp.transform.position = collision.collider.transform.position;
            health--;
        }
        if (collision.collider.CompareTag("Bounds"))
        {
            Vector3 newDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.rotation = Quaternion.LookRotation(newDirection);
            print("new dir = " + newDirection);
        }
    }
}
