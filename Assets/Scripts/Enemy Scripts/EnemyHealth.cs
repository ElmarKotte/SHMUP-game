using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public GameObject explosion;
    public GameObject hitExplosion;
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
        GameObject exp = Instantiate(explosion);
        exp.transform.position = transform.position;
        GM.addScore(100);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            changeHealth(-1);
            GameObject exp = Instantiate(hitExplosion);
            exp.transform.position = collision.collider.transform.position;
        }

        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().changeHealth(-1);
            killed();
        }
    }
}
