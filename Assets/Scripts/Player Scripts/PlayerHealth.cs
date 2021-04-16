using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool godmode;
    public gameManager GM;

    public HealtBarScript HealtBar;

    public float invisTime;
    float invisTimer;

    public void Start()
    {
        HealtBar = FindObjectOfType<HealtBarScript>();
        GM = FindObjectOfType<gameManager>();
    }

    private void Update()
    {
        // will trikker killed() when no hp is remaining
        if (health <= 0) killed();
        if (godmode)
        {
            health = maxHealth;
        }
        invisTimer += Time.deltaTime;
    }

    // public function to change health
    public void changeHealth(int change)
    {
        health += change;
        HealtBar.UpdateHealthBar();
        invisTimer = 0;
    }

    // function to kill the enemy when hp is <= 0
    private void killed()
    {
        GM.PlayerGameStates = PlayerGameStates.dead;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (invisTimer >= invisTime)
        {
            if (collision.collider.CompareTag("EnemyBullet"))
            {
                changeHealth(-1);
                Destroy(collision.collider.gameObject);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (invisTimer >= invisTime)
        {
            if (other.CompareTag("WormBoss"))
            {
                changeHealth(-1);
            }
        }
    }
}
