using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Enemy_Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public bool isDead = false;
    Animator anim;
    WaitForFixedUpdate wait;
    Rigidbody2D rigid;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth <= 0)
        {
            Dead();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        currentHealth -= collision.GetComponent<Bullet>().damage;
        //StartCoroutine(KnockBack());
        if(currentHealth > 0)
        {
            anim.SetTrigger("Hit");

        }
        else
        {
            isDead = true;
            anim.SetBool("Dead", true);
        }
    }

    IEnumerator KnockBack()
    {
        yield return null; //1프레임 쉬기
        Vector3 playerPos = Gamemanager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized*2, ForceMode2D.Impulse);
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
