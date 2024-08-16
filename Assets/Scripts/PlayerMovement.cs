using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 4f; // Set to 4 units per second

    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            // Stop the player from moving out of bounds
            RestrictMovement(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            // Continuously restrict movement if the player is still trying to exit
            RestrictMovement(other);
        }
    }

    void RestrictMovement(Collider2D boundary)
    {
        // Get the closest point on the boundary collider's perimeter to the player's position
        Vector2 closestPoint = boundary.ClosestPoint(transform.position);

        // Set the player's position to that closest point, preventing them from moving out
        transform.position = closestPoint;
    }
}

