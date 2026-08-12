using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public int facingDirection = 1;

    public Rigidbody2D rb;
    public Animator anim;

    // Fixed Update is called x50 frame
    void FixedUpdate()
    {
        //gets player input for horizontal (keybinds: Edit -> Proj settings -> input manager)
        //left = -1 , right = +1 , no input = 0
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //if we are pressing right but facing left OR pressing left but facing right
        //transform.localScale.x is what you find in transform where you can set the orientation of the player
        if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
            
        void Flip()
        {
            //flips facing direction
            facingDirection *= -1;
            // *= -1 doesnt work here as you cant modify a single aspect of the local scale, so you have to modify all 3 
            transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        //sets animators floats to mirror our button presses
        //Mathf.Abs turn numbers into absolute (+ve numbers), so moving left will laso be positive
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        //velocity = direction * speed
        //vector2 = (x,y)
        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
