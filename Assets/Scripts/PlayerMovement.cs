using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;

    public Camera cam;
    public Vector2 mousePos;

    public float dashCooldown = 1;

    public static PlayerMovement instance;

    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    void FixedUpdate()
    {
        moveCharacter(movement);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

        if(Input.GetAxis("Jump") == 1 && dashCooldown <= 0)
        {
            dash(movement);
            
            dashCooldown = 1;
            
        }
        
        dashCooldown -= Time.deltaTime;
    }
    void moveCharacter(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }
    void dash(Vector2 direction)
    {
        rb.velocity = direction * speed * 10;
    }
}
