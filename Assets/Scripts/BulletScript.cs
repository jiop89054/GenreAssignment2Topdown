using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BulletScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackCooldown;
    public float bulletForce = 20f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && attackCooldown <= 0 && PlayerHealth.instance.PlayerCurrentHealth > 0) 
        {
            Shoot();
            FindObjectOfType<AudioManager>().Play("PlayerPew");
            attackCooldown = 1;
        }
        attackCooldown -= (Time.deltaTime * 5);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
