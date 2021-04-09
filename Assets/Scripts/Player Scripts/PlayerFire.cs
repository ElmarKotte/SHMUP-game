using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform firePointOne;
    public Transform firePointTwo;
    private Transform bulletList;
    private float fireTimer;
    public float bulletForce;
    [SerializeField] private float fireRate;
    void Start()
    {
        bulletList = GameObject.Find("BulletList").transform;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer = fireTimer + Time.deltaTime;
        if (Input.GetButton("Fire1") && fireTimer > fireRate)
        {
            Fire();
        }
    }
    private void FixedUpdate()
    {
        
    }

    public void Fire()
    {
        GameObject bulletOne = Instantiate(playerBullet, firePointOne.position, new Quaternion());
        Rigidbody rbOne = bulletOne.GetComponent<Rigidbody>();
        rbOne.AddForce(0, 0, bulletForce, ForceMode.Impulse);
        bulletOne.transform.SetParent(bulletList);

        GameObject bulletTwo = Instantiate(playerBullet, firePointTwo.position, new Quaternion());
        Rigidbody rbTwo = bulletTwo.GetComponent<Rigidbody>();
        rbTwo.AddForce(0, 0, bulletForce, ForceMode.Impulse);
        bulletTwo.transform.SetParent(bulletList);
        fireTimer = 0;
    }
}
    