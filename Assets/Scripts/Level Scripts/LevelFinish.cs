using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    PlayerMovement player;
    public GameObject panal;
    void Start()
    {
        panal.SetActive(false);
        player = GetComponent<PlayerMovement>();
    }  
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            panal.SetActive(true);           
        }
    }
}
