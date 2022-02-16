using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    private Vector2 directionToPlayer;
    public Rigidbody2D rb;
    private Vector2 enemyPos;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackCooldown;
    public float bulletForce = 10f;

    private void FixedUpdate()
    {
        Vector2 playerPos = PlayerMovement.instance.rb.position;
        enemyPos = rb.position;
        directionToPlayer = playerPos - enemyPos;

        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        


    }
    private void Update()
    {
        if(attackCooldown < 0)
        {
            Shoot();
            attackCooldown = 1;
        }
        attackCooldown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("EnemyShot");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {

            Death();
        }
    }
    private void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyKilled");
        Destroy(gameObject);
    }
}
