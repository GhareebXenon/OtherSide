using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 5;
    public Character healthBar;
    Transform targetDestination;
    GameObject targetGameobject;
    [SerializeField] float speed;

    Rigidbody2D rgdbd2d;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject )
        {
            Attack();
        }
    }
    private void Attack()
    {
       // Debug.Log("Attacking the Player!!");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            healthBar.TakeDamge(damage);
        }
    }
   
}
