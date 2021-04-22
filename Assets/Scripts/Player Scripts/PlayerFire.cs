using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireMode
{
    normal,
    fast,
    spread,
    super
}

public class PlayerFire : MonoBehaviour
{

    public GameObject playerBullet;

    public Transform firePointOne;
    public Transform firePointTwo;
    private Transform bulletList;

    private float fireTimer;
    public float bulletForce;
    [SerializeField] private float fireRate;

    public FireMode fireMode;

    AudioSource audioSource;
    public AudioClip fire;

  
    void Start()
    {
        bulletList = GameObject.Find("BulletList").transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer = fireTimer + Time.deltaTime;
        if (Input.GetButton("Fire1") && fireTimer > fireRate || Input.GetKey(KeyCode.Space) && fireTimer > fireRate)
        {
            audioSource.PlayOneShot(fire, 0.5f);
            if (fireMode == FireMode.normal || fireMode == FireMode.fast)
                FireNormal();
            if (fireMode == FireMode.spread)
                FireSpread();
            if (fireMode == FireMode.super) 
            FireSuper();

        }
    }
    private void FixedUpdate()
    {

    }

    public void setFireMode(FireMode mode)
    {
        fireMode = mode;
    }
    private void FireSpread()
    {
        GameObject bulletOne = Instantiate(playerBullet, firePointOne.position, new Quaternion());
        Rigidbody rbOne = bulletOne.GetComponent<Rigidbody>();
        bulletOne.transform.Rotate(new Vector3(0, 20, 0));
        rbOne.AddForce(10, 0, bulletForce - 10, ForceMode.Impulse);
        bulletOne.transform.SetParent(bulletList);

        GameObject bulletTwo = Instantiate(playerBullet, firePointTwo.position, new Quaternion());
        Rigidbody rbTwo = bulletTwo.GetComponent<Rigidbody>();
        bulletTwo.transform.Rotate(new Vector3(0, -20, 0));
        rbTwo.AddForce(-10, 0, bulletForce - 10, ForceMode.Impulse);
        bulletTwo.transform.SetParent(bulletList);

        GameObject bulletThree = Instantiate(playerBullet, firePointOne.position, new Quaternion());
        Rigidbody rbThree = bulletThree.GetComponent<Rigidbody>();
        rbThree.AddForce(0, 0, bulletForce, ForceMode.Impulse);
        bulletThree.transform.SetParent(bulletList);

        GameObject bulletFour = Instantiate(playerBullet, firePointTwo.position, new Quaternion());
        Rigidbody rbFour = bulletFour.GetComponent<Rigidbody>();
        rbFour.AddForce(0, 0, bulletForce, ForceMode.Impulse);
        bulletFour.transform.SetParent(bulletList);
        fireTimer = -0.2f;
    }

    private void FireNormal()
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
        if (fireMode == FireMode.fast)
            fireTimer = fireRate / 2;
    }

    private void FireSuper()
    {
        GameObject bulletOne = Instantiate(playerBullet, firePointOne.position, new Quaternion());
        Rigidbody rbOne = bulletOne.GetComponent<Rigidbody>();
        bulletOne.transform.Rotate(new Vector3(0, 20, 0));
        rbOne.AddForce(10, 0, bulletForce - 10, ForceMode.Impulse);
        bulletOne.transform.SetParent(bulletList);

        GameObject bulletTwo = Instantiate(playerBullet, firePointTwo.position, new Quaternion());
        Rigidbody rbTwo = bulletTwo.GetComponent<Rigidbody>();
        bulletTwo.transform.Rotate(new Vector3(0, -20, 0));
        rbTwo.AddForce(-10, 0, bulletForce - 10, ForceMode.Impulse);
        bulletTwo.transform.SetParent(bulletList);

        GameObject bulletThree = Instantiate(playerBullet, firePointOne.position, new Quaternion());
        Rigidbody rbThree = bulletThree.GetComponent<Rigidbody>();
        rbThree.AddForce(0, 0, bulletForce, ForceMode.Impulse);
        bulletThree.transform.SetParent(bulletList);

        GameObject bulletFour = Instantiate(playerBullet, firePointTwo.position, new Quaternion());
        Rigidbody rbFour = bulletFour.GetComponent<Rigidbody>();
        rbFour.AddForce(0, 0, bulletForce, ForceMode.Impulse);
        bulletFour.transform.SetParent(bulletList);

        GameObject bulletFive = Instantiate(playerBullet, firePointOne.position, new Quaternion());
        Rigidbody rbFive = bulletFive.GetComponent<Rigidbody>();
        bulletFive.transform.Rotate(new Vector3(0, -10, 0));
        rbFive.AddForce(-5, 0, bulletForce - 5, ForceMode.Impulse);
        bulletFour.transform.SetParent(bulletList);

        GameObject bulletSix = Instantiate(playerBullet, firePointTwo.position, new Quaternion());
        Rigidbody rbSix = bulletSix.GetComponent<Rigidbody>();
        bulletSix.transform.Rotate(new Vector3(0, 10, 0));
        rbSix.AddForce(5, 0, bulletForce - 5, ForceMode.Impulse);
        bulletSix.transform.SetParent(bulletList);
        fireTimer = 0.1f;
    }
}
