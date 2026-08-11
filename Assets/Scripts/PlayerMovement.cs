using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody2D rb;


    // Fixed Update is called x50 frame
    void FixedUpdate()
    {
        //gets player input for horizontal (keybinds: Edit -> Proj settings -> input manager)
        //left = -1 , right = +1 , no input = 0
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //velocity = direction * speed
        //vector2 = (x,y)
        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
