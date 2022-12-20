using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Kit : MonoBehaviour
{
    public Character character;
    public int health;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            character.Heal(health);
        }
        Destroy(this.gameObject);
    }
}
