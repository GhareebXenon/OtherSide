using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5;
    private Vector2 moveDir;
    
    private void Update()
    {
        ProcessInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
        
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
         
    }


}
