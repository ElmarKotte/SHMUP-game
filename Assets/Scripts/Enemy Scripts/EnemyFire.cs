using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject enemyBullelt;
    public Transform enemyFirePoint;
    public Transform bulletList;
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
        if (fireTimer > fireRate)
        {
            Fire();
        }
    } 
    public void Fire()
    {
        GameObject bullet = Instantiate(enemyBullelt, enemyFirePoint.position, enemyFirePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * -1 * bulletForce, ForceMode.Impulse);   
        fireTimer = 0;
        bullet.transform.SetParent(bulletList);
    }
}
    