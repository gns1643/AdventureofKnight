using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed = 5;
    public int facingDirection = 1;
    private Rigidbody2D rb;
    public Transform player;
    Animator anim;
    Enemy_Health health;

    private void Start()
    {
        health = GetComponent<Enemy_Health>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = Gamemanager.instance.player.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if (health.isDead)
        {
            rb.linearVelocity = Vector2.zero; //  추가: 속도 초기화
            return;
        }
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
