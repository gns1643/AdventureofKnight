using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Enemy_Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

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
        Debug.Log("ÃÑ¾Ë µ¥¹ÌÁö : " + currentHealth);
        if(currentHealth > 0)
        {

        }
        else
        {
            Dead();
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
