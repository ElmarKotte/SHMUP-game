using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryOverLIfetime : MonoBehaviour
{
    public float lifeTime = 1;
    float timeAlive;
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
