using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public gameManager GM;
    public LayerMask collisionLayers;
    public LayerMask playerLayer;

    private void Start()
    {
        GM = FindObjectOfType<gameManager>();
    }
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
        GM.addScore(100);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("trigger enterd " + collision.collider.name);
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            print("Changing health of " + gameObject.name);
            changeHealth(-1);
        }

        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().changeHealth(-1);
            killed();
        }
    }
}
