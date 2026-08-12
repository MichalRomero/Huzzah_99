using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody2D rb;
    public Animator anim;

    // Fixed Update is called x50 frame
    void FixedUpdate()
    {
        //gets player input for horizontal (keybinds: Edit -> Proj settings -> input manager)
        //left = -1 , right = +1 , no input = 0
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //sets animators floats to mirror our button presses
        //Mathf.Abs turn numbers into absolute (+ve numbers), so moving left will laso be positive
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        //velocity = direction * speed
        //vector2 = (x,y)
        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
