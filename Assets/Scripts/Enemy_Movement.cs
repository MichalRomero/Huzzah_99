using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.XR;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;

    //facing right
    private int facingDirection = 1;

    [Header("Testing for enemy state")] // tracks current state
    public EnemyState enemyState;
    private Rigidbody2D rb;
    public Transform player;
    private Animator anim;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Change the state to Chasing to begin the game
        ChangeState(EnemyState.Chasing);
    }

    // Update is called once per frame
    void Update()
{
    if (enemyState == EnemyState.Chasing)
    {
        //if plaeyrs is on right side of enemy and enemy facing left, then flip
        if (player.position.x > transform.position.x && facingDirection == -1)
        {
            Flip();
        }
        //if plaeyrs is on left side of enemy and enemy facing right, then flip
        else if (player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
}

    void Flip()
        {
            //flips facing direction
            facingDirection *= -1;
            // *= -1 doesnt work here as you cant modify a single aspect of the local scale, so you have to modify all 3 
            transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

    
    void ChangeState(EnemyState newState)
    {
        //Exit current animation
        //sets the booleans (found in animator) to true or false depensing on state
        if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }
        else if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }

        //update current state
        //sets new state to whatever was just passed in
        enemyState = newState;

        //Update new animation
        //now that new state is set, we have to set the booleans to true or false depending on what it is
        if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }
        else if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }

    }
}


public enum EnemyState
{
    Idle,
    Chasing,
}