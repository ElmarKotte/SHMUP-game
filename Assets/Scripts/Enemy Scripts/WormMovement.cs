using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    public List<Transform> BodyParts = new List<Transform>();
    public float minDistance = 0.25f;
    public float speed = 1f;
    public float rotationFrequency = 50f;
    public float rotationAmmount = 50f;

    public int beginSize;

    public GameObject bodyPrefab;
    private float previousPerlin = 0;
    private float mapTime;
    private float distance;
    private Transform currentBoddypart;
    private Transform prevBoddypart;
    void Start()
    {
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBoddyPart();
        }
    }
    public void AddBoddyPart()
    {
        Transform newpart = Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation).transform;

        newpart.SetParent(transform);

        BodyParts.Add(newpart);
    }

    public void Rotate()
    {

        mapTime += Time.deltaTime * rotationFrequency;

        float currentPerlin = Mathf.PerlinNoise(mapTime, 0);
        float R = (currentPerlin - previousPerlin) * rotationAmmount;

        BodyParts[0].Rotate(new Vector3(0, R, 0));
        previousPerlin = currentPerlin;
    }

    public void Move()
    {
        BodyParts[0].Translate(BodyParts[0].forward * speed * Time.smoothDeltaTime, Space.World);
        Rotate();

        for (int i = 1; i < BodyParts.Count; i++)
        {
            currentBoddypart = BodyParts[i];

            prevBoddypart = BodyParts[i - 1];


            distance = Vector3.Distance(prevBoddypart.position, currentBoddypart.position);

            Vector3 newPos = prevBoddypart.position;

            newPos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * distance / minDistance * speed;

            if (T > 0.5f)
                T = 0.5f;

            currentBoddypart.position = Vector3.Slerp(currentBoddypart.position, newPos, T);
            currentBoddypart.rotation = Quaternion.Slerp(currentBoddypart.rotation, prevBoddypart.rotation, T);
        }
    }
    void Update()
    {
        Move();
    }
}
