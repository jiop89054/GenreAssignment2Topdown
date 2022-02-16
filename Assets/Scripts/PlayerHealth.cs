using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float PlayerMaxHealth = 100;
    public float PlayerCurrentHealth;
    public Rigidbody2D rb;
    public Slider healthBar;
    public ParticleSystem blood;
    public SpriteRenderer spriteRend;

    public float iFramesLength;
    public int flashNumber;
    public bool hasDied;

    public static PlayerHealth instance;

    private void Awake()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        healthBar.maxValue = PlayerMaxHealth;
        healthBar.value = PlayerMaxHealth;
        instance = this;
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 10, false);
    }
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Music");
    }
    public void FixedUpdate()
    {
        if(PlayerCurrentHealth < 100 && PlayerCurrentHealth > 0)
        PlayerCurrentHealth += 1 * Time.deltaTime;
        healthBar.value = PlayerCurrentHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            PlayerCurrentHealth = -1;
            healthBar.value = PlayerCurrentHealth;
            Death();
        }  
    }
    public void takeDamage(float amount)
    {
        FindObjectOfType<ShakeBehavior>().shakeDuration = 1;
        FindObjectOfType<AudioManager>().Play("PlayerDamage");
        PlayerCurrentHealth -= amount;
        healthBar.value = PlayerCurrentHealth;
        if(PlayerCurrentHealth > 0)
        StartCoroutine(Invulnerability());
        else
            Death();
    }
    public void Death()
    {
        if(!hasDied)
        spriteRend.color = new Color(0, 0, 0, 0.0f);
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        blood.gameObject.SetActive(true);
        print("Triggering Death Function");
        
        Invoke("triggerLoseScreen", 1);
        hasDied = true;

    }
    public void triggerLoseScreen()
    {
        blood.gameObject.SetActive(false);
        FindObjectOfType<MenuScript>().LoadLevel("Lose Screen");
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
        //invulnerability duration
        for (int i = 0; i < flashNumber; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesLength / (flashNumber));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesLength / (flashNumber));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 10, false);
    }
}
