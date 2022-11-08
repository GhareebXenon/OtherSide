using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //components 
    [SerializeField] private Rigidbody2D rb;
    //Player 

    private float walkSpeed = 8f;
    
    float inputHorizontal;
    float inputVertical;

    
    

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal, inputVertical).normalized * walkSpeed;
    }

    
}
