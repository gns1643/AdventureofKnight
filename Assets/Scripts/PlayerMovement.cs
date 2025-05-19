using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float h;
    float v;
    //publlic int facing
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
        rigid.linearVelocity = moveVec * 5;

        anim.SetInteger("IntH", Mathf.Abs((int)h));
        anim.SetInteger("IntV", Mathf.Abs((int)v));

        Debug.Log(h + " " + v);
    }
}
