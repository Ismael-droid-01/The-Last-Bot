using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rbd2D;
    private float move;
    private SpriteRenderer spriteRenderer;

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
    }
}
