using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
      [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _moveSpeed;
    public void Shoot(Vector3 mousePos) {
        _rigidbody2D.velocity = _moveSpeed * (mousePos - transform.position);
        Destroy(this.gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            //Kill Enemy Here
            //collision.gameObject.GetComponent<Enemy>();
            Destroy(this.gameObject);
        }
    }
}
