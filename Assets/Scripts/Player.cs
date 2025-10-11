using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rbd2D;
    private float move;
    private SpriteRenderer spriteRenderer;
    private float jumpForce = 8;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rbd2D.linearVelocity = new Vector2(move * speed, rbd2D.linearVelocity.y);

        if (move != 0)
        {
            spriteRenderer.flipX = move < 0; // voltea el sprite en lugar de escalarlo
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rbd2D.linearVelocity = new Vector2(rbd2D.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
}
