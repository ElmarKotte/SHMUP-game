using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    public List<Transform> BodyParts = new List<Transform>();
    public List<GameObject> parts = new List<GameObject>();
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
    private Transform currentBoddypart;
    private Transform prevBoddypart;

    public void spawn()
    {
        // Maak de aantal body parts aan zodra de worm spawnt
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBoddyPart();
        }
    }

    // functie die een bodypart aan maakt
    public void AddBoddyPart()
    {
        Transform newpart = Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation).transform;
        Transform newParent = transform;
        newpart.SetParent(newParent);

        parts.Add(newpart.gameObject);
        BodyParts.Add(newpart);
        newpart.GetComponent<BoundsWorm>().front = gameObject;
    }


    // dit de eerste keer is dat ik PerlinNoise gebruik
    // Deze funcite rotate de worm me een bepaalde frequency en een bepaalde snelheid met smooth rotation
    public void Rotate()
    {
        mapTime += Time.deltaTime * rotationFrequency;

        float currentPerlin = Mathf.PerlinNoise(mapTime, 0);
        float R = (currentPerlin - previousPerlin) * rotationAmmount;

        BodyParts[0].Rotate(new Vector3(0, R, 0));
        previousPerlin = currentPerlin;
    }

    // Deze funcite beweegt alle body parts achter de gene voor zich aan 
    public void Move()
    {
        BodyParts[0].Translate(BodyParts[0].forward * currentSpeed * Time.smoothDeltaTime, Space.World);
        Rotate();

        // i begint op 1 omdat de head niks heeft als PreviousBoddyPart en dus ook niet zo hoeft te bewegen
        for (int i = 1; i < BodyParts.Count; i++)
        {
            currentBoddypart = BodyParts[i];
            prevBoddypart = BodyParts[i - 1];

            distance = Vector3.Distance(prevBoddypart.position, currentBoddypart.position);
            Vector3 newPos = prevBoddypart.position;
            newPos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * distance / minDistance * currentSpeed;

            if (T > 0.5f)
                T = 0.5f;

            currentBoddypart.position = Vector3.Slerp(currentBoddypart.position, newPos, T);
            currentBoddypart.rotation = Quaternion.Slerp(currentBoddypart.rotation, prevBoddypart.rotation, T);
        }

    }

    public void CheckForNewHead()
    {

        wormSpawner = GameObject.FindGameObjectWithTag("WormSpawner").transform;

        for (int i = 1; i < parts.Count; i++)
        {
            if (parts[i] != null)
            {
                WormPart script = parts[i].GetComponent<WormPart>();
                if (script.health <= 0)
                {
                    //GameObject GO = Instantiate(headPrefab, parts[i].transform.position, Quaternion.identity, wormSpawner);
                    BodyParts.Remove(parts[i].transform);
                    GameObject newHead = parts[i];
                    parts[i].tag = "WormBoss";
                    parts.Remove(parts[i]);
                    script.isHead = true;
                    script.health = 5;
                    for (int j = i; j < parts.Count; j++)
                    {
                        script.parts.Add(parts[i]);
                        script.BodyParts.Add(parts[i].transform);
                        parts[i].GetComponent<BoundsWorm>().front = newHead;
                        //parts[i].transform.parent = newHead.transform;
                        BodyParts.Remove(parts[i].transform);
                        parts.Remove(parts[i]);
                    }
                }
            }

        }
    }

    public void Boost()
    {
        currentSpeed = boostMultiplier * minSpeed;
    }

    void Update()
    {
        Move();

        currentSpeed -= speedLoss * Time.deltaTime;
        if (currentSpeed < minSpeed)
        {
            currentSpeed = minSpeed;
        }

        CheckForNewHead();
    }

}
