using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health, maxhealth = 5;
    public HealthBar healthBar;
    void Start()
    {
        health =  maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.SetHealth(health);
        if (health <= 0)     // (Enemy death)
        {
            Destroy(gameObject);
        }
    }
    
}
