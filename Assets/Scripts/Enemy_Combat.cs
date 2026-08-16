using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    //for now enemy does damage by walking into them

    public int damage = 1;

    //OnCollisionEnter2D fires when enemy hits a collider
    //Collision2D the type of collision it will look for
    //collision keeps track of te last collider the enemy hit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //find colliders gameobject, get the playerhealth component, then call our change health method to do -damage
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
        
    }
}
