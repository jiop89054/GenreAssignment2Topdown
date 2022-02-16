using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StafeEnemy : MonoBehaviour
{
    public Transform strafer;
    public float speed;
    private Vector2 enemyPos;
    private Vector2 directionToPlayer;
    public Rigidbody2D rb;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackCooldown;
    public float bulletForce = 6f;

    private void FixedUpdate()
    {
        Vector2 playerPos = PlayerMovement.instance.rb.position;
        enemyPos = rb.position;
        directionToPlayer = playerPos - enemyPos;
        //rb.velocity = directionToPlayer.normalized * speed;

        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 20f;
        rb.rotation = angle;
        rb.velocity = strafer.up * speed;
    }

    private void Update()
    {
        if (attackCooldown < 0)
        {
            Shoot();
            attackCooldown = 1;
        }
        attackCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("EnemyShot");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 7)
        {

            Death();
        }
        if (collision.gameObject.layer == 8)
        {
            FindObjectOfType<PlayerHealth>().takeDamage(20);
        }
    }
    public void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyKilled");
        Destroy(gameObject);
    }
}
