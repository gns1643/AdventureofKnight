using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float h;
    float v;
    public int facingDirection = 1;
    public Rigidbody2D rigid;
    public Animator anim;
    public Vector2 moveVec;

    public Scanner scanner;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        scanner = GetComponent<Scanner>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        moveVec = new Vector2(h, v).normalized;

        //if (h > 0 && transform.localScale.x < 0 ||
        //    h < 0 && transform.localScale.x > 0)
        //{
        //    Flip();
        //} // 버그로인해 비활성


        anim.SetInteger("IntH", Mathf.Abs((int)h));
        anim.SetInteger("IntV", Mathf.Abs((int)v));
        rigid.linearVelocity = moveVec * 5;
    }
    void Flip()
    {
        facingDirection *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

