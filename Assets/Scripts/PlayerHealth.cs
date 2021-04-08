using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private void Update()
    {
            // will trikker killed() when no hp is remaining
        if (health <= 0) killed();
       
    }

        // public function to change health
    public void changeHealth(int change)
    {
        health += change;
    }

        // function to kill the enemy when hp is <= 0
    private void killed()
    {
        Destroy(gameObject);
    }

}
