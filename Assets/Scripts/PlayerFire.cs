using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform firePoint;
    private float fireTimer;
    public float bulletForce;
    [SerializeField] private float fireRate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer = fireTimer + Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            Fire();
        }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(playerBullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode2D.Impulse);
        fireTimer = 0;
    }
}
    