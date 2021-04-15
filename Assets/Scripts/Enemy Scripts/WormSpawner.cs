using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawner : MonoBehaviour
{
    public GameObject wormBossPrefab;
    public GameObject wormBossInstance;
    void Start()
    {
        wormBossInstance = Instantiate(wormBossPrefab, transform.position, Quaternion.identity, transform);
        wormBossInstance.GetComponent<WormMovement>().spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
