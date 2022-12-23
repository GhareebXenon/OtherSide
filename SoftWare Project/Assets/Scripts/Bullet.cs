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
  
}
