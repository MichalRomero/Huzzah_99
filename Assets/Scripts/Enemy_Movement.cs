using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;

    private bool isChasing;

    private Rigidbody2D rb;
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isChasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChasing == true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
        
    }
}
