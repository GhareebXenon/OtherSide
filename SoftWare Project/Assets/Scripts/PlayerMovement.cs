using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //components 
    [SerializeField] private Rigidbody2D rb;
    //Player 

    [SerializeField]private float walkSpeed = 7f;
    
    float inputHorizontal;
    float inputVertical;

    //anim
    

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
