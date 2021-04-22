using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    PlayerMovement player;
    public GameObject panal;
    public GameObject gameOver;
    public GameObject levelComplete;
    public GameObject paused;
    public bool levelDone;
    public GameObject NextLevelButton;
    public gameManager GM;
    public bool isMenuUp = false;

    AudioSource audioSource;
    public AudioClip fire;

    public int Level = 1;
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        NextLevelButton.SetActive(false);
        levelDone = false;
        panal.SetActive(false);
        levelComplete.SetActive(false);
        gameOver.SetActive(false);
        paused.SetActive(false);
        player = FindObjectOfType<PlayerMovement>();
        GM = FindObjectOfType<gameManager>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isMenuUp == false && levelDone == false)
            {
                paused.SetActive(true);
                Time.timeScale = 0;
                panal.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                isMenuUp = true;
            }
            else if (isMenuUp == true && levelDone == false)
            {
                paused.SetActive(false);
                Time.timeScale = 1;
                panal.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isMenuUp = false;               
            }
        }

        if (GM.PlayerGameStates == PlayerGameStates.dead)
        {
            panal.SetActive(true);
            gameOver.SetActive(true);
            paused.SetActive(false);


            levelComplete.SetActive(false);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            player.speed = 0;
          
            panal.SetActive(true);
            paused.SetActive(false);
            levelDone = true;
            levelComplete.SetActive(true);
            NextLevelButton.SetActive(true);
            gameManager gm = FindObjectOfType<gameManager>();
            gm.levelEnd(Level);
        }
    }
}
