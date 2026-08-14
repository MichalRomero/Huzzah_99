using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private bool isChasing = true;
    //facing right
    private int facingDirection = 1;

    private Rigidbody2D rb;
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
{
    if (isChasing)
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
}
