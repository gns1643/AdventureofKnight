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
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(h, v).normalized;
        
        if(h > 0 && transform.localScale.x <0 ||
            h < 0 && transform.localScale.x > 0)
        {
            Flip();
        }


        anim.SetInteger("IntH", Mathf.Abs((int)h));
        anim.SetInteger("IntV", Mathf.Abs((int)v));
        rigid.linearVelocity = moveVec * 5;
        Debug.Log(h + " " + v);
    }
    void Flip()
    {
        facingDirection += -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,
            transform.localScale.y, transform.localScale.z);
    }
}
