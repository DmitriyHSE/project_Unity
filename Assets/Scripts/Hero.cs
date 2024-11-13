using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] public bool isFalling = false;

    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public static Hero Instance { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }

    private void FixedUpdate()
    {
        isFalling = rb.linearVelocity.y < 0;
        CheckGround();
    }

    private void Update()
    {
        Move();
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        if (direction != 0)
            sprite.flipX = direction < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = colliders.Length > 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFalling && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}



