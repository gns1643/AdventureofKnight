using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed = 5;
    public int facingDirection = 1;
    private Rigidbody2D rb;
    public Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = Gamemanager.instance.player.GetComponent<Transform>();
    }
    private void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
        if (direction.x < 0 && facingDirection > 0 ||
            direction.x > 0 && facingDirection < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingDirection *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}
