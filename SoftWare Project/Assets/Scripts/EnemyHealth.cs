using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health, maxhealth = 5;
    public HealthBar healthBar;
    public int damage = 5;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Kill Enemy Here
            Destroy(collision.gameObject);
            //Destroy(this.gameObject);
            TakeDamage(damage);
        }

    }
}
