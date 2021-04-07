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
    private void FixedUpdate()
    {
        
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(playerBullet, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, bulletForce, ForceMode.Impulse);
        //rb.AddForce(firePoint.forward * bulletForce);
        fireTimer = 0;
    }
}
    