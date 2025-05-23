using System;
using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public TMP_Text healthText;
    public Animator healthTextAnim;

    private void Start()
    {
        healthText.text = "HP : " + currentHealth + " / " + maxHealth;
    }
    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        healthText.text = "HP : " + currentHealth + " / " + maxHealth;
        healthTextAnim.Play("TextActive");
        if (currentHealth <= 0)
        {
            Debug.Log("플레이어가 사망하였습니다");
        }
    }
}
