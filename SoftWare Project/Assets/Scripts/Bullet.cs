using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _moveSpeed;
    public EnemyHealth HealthBar;

    public int damage = 5;
    
    public void Shoot(Vector3 mousePos)
    {
        _rigidbody2D.velocity = _moveSpeed * (mousePos - transform.position).normalized;
        Destroy(this.gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Boss")
        {
            //Kill Enemy Here
            
            Destroy(this.gameObject);
            HealthBar.TakeDamage(damage);
           
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            //Kill Enemy Here
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
           // HealthBar.TakeDamage(damage);
        }
        
    }
   
}
