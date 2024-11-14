using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = false;
    [SerializeField]
    private float groundCheckDistance;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Animator animator;

    public bool isFalling = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void Update()
    {   
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckDistance, whatIsGround);
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("moveX", Mathf.Abs(movement.x));
        Jump();
    }

    public void Movement()
    {

        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);

        if (movement.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }

        if(movement.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            animator.SetBool("jumping", false);
        }
        else
        {
            animator.SetBool("jumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    void FixedUpdate()
    {
        isFalling = rb.linearVelocity.y < 0;
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFalling && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
