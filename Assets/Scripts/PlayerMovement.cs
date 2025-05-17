using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float h;
    float v;
    Vector3 dirvec;
    bool isHorizonMove;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        bool hDown =  Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp =  Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp)
        {
            isHorizonMove = true;
        }
        else if (vDown || hUp)
        {
            isHorizonMove = false;
        }

        if (vDown && v == 1)
            dirvec = Vector3.up;
        //���� : ��
        if (vDown && v == -1)
            dirvec = Vector3.down;
        //���� : ��
        if (hDown && h == -1)
            dirvec = Vector3.left;
        //���� : ��
        if (hDown && h == 1)
            dirvec = Vector3.right;
    }
    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ?
            new Vector2(h, 0) :
            new Vector2(0, v);
        rigid.linearVelocity = moveVec * 5;

        Debug.Log("�ӵ�: " + rigid.linearVelocity); // �� ���⿡ �ָ�
    }
}
