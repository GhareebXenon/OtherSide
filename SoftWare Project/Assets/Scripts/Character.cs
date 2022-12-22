using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
  
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

   /* void Update()
    {
         if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Heal(10);
        }
   }*/
    public void TakeDamge(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)     // (player death)
        {
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
        }
    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
  
}
