using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 8)
        {
            FindObjectOfType<PlayerHealth>().takeDamage(20);
            Destroy(gameObject);
        }
    }
}
