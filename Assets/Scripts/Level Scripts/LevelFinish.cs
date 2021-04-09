using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    PlayerMovement player;
    public GameObject panal;
    public GameObject NextLevelButton;
    public gameManager GM;
    void Start()
    {
        NextLevelButton.SetActive(false);
        panal.SetActive(false);
        player = FindObjectOfType<PlayerMovement>();
        GM = FindObjectOfType<gameManager>();
    }  
    void Update()
    {
        if(GM.PlayerGameStates == PlayerGameStates.dead)
        {
            panal.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            player.speed = 0;
            panal.SetActive(true);
            NextLevelButton.SetActive(true);
        }
    }
}
