using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector2 mousePos;
    [SerializeField] private Rigidbody2D spriteAimRb;
    [SerializeField] private SpriteRenderer spriteAim;


    private void processAim()
    {
        mousePos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

    }
    private void Update()
    {
        processAim();




    }
    private void FixedUpdate()
    {
        aim();
    }
    private void aim()
    {
        Vector2 aimDirection = mousePos - spriteAimRb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        
    }


}
