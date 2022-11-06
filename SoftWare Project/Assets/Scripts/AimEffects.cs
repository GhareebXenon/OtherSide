using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class AimEffects : MonoBehaviour
{
    [SerializeField] private PlayerAim playerAim;
    private void Start()
    {
        playerAim.OnShoot += playerAim_OnShoot;

    }
    private void playerAim_OnShoot(object sender, PlayerAim.OnShootEventArgs e)
    {

    }


}
