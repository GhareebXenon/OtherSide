using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform aimTransform;
    private Animator aimAnim;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimAnim = aimTransform.GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        AimHandler();
        ShootingHandler();
    }
    //Aim Move With the transform of the mouse 
    private void AimHandler()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        //Follow the mouse in the z axis only
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        

    }
    private void ShootingHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aimAnim.SetTrigger("Shoot");   

        }
    }
}
