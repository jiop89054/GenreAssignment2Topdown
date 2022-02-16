using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript1 : MonoBehaviour
{
    public float speed;
    private Vector2 enemyPos;
    private Vector2 directionToPlayer;
    public Rigidbody2D rb;
    
    private void FixedUpdate()
    {
        Vector2 playerPos = PlayerMovement.instance.rb.position;
        enemyPos = rb.position;
        directionToPlayer = playerPos - enemyPos;
        rb.velocity = directionToPlayer.normalized * speed;

        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.layer == 7)
        {
            
            Death();
        }
        if(collision.gameObject.layer == 8)
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
