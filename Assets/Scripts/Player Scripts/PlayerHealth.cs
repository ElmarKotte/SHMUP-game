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

    public void Start()
    {
        HealtBar.SetMaxHealt(maxHealth);
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
    }

    // public function to change health
    public void changeHealth(int change)
    {
        health += change;
        HealtBar.SetHealth(health);
    }

    // function to kill the enemy when hp is <= 0
    private void killed()
    {
        GM.PlayerGameStates = PlayerGameStates.dead;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            changeHealth(-1);
            Destroy(collision.collider.gameObject);
        }
    }
}
