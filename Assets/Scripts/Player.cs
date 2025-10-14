using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rbd2D;
    private float move;
    private SpriteRenderer spriteRenderer;
    private float jumpForce = 8.5f;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    private Animator animator;
    public TMP_Text textLives;
    private int lives;

    void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        lives = 100;
        textLives.text = lives.ToString();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rbd2D.linearVelocity = new Vector2(move * speed, rbd2D.linearVelocity.y);

        if (move != 0)
            spriteRenderer.flipX = move < 0;

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rbd2D.linearVelocity = new Vector2(rbd2D.linearVelocity.x, jumpForce);
        }

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity", rbd2D.linearVelocity.y);
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hammer") || collision.CompareTag("Entry"))
        {
            if (lives == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                // Destroy(collision.gameObject);
                lives--;
                textLives.text = lives.ToString();
            }
        }

        if (collision.CompareTag("Finish"))
        {
            Debug.Log("Ha llegado al final");
        }
    }
}
