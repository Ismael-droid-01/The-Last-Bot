using UnityEngine;
//using UnityEngine.SceneManagement;
using TMPro;

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
    private Animator animator;
    public TMP_Text textLives;
    private int lives;

    void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        lives = 3;
        textLives.text = lives.ToString();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rbd2D.linearVelocity = new Vector2(move * speed, rbd2D.linearVelocity.y);

        if (move != 0)
        {
            spriteRenderer.flipX = move < 0; // voltea el sprite en lugar de escalarlo
        }

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
        if (collision.transform.CompareTag("Hammer"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            lives--;
            textLives.text = lives.ToString();
        }
    }
}
