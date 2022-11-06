using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAim : MonoBehaviour
{
    //Events
    public event EventHandler <OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 gunEndPointPosition;
        public Vector3 ShotPosition;



    }
    // Start is called before the first frame update
    private Transform aimTransform;
    [SerializeField] private Transform GunEndPointTransform;
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
    //shoting Animation
    private void ShootingHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            aimAnim.SetTrigger("Shoot");
            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = GunEndPointTransform.position,
                ShotPosition = mousePosition
            }) ;




        }
    }
}
