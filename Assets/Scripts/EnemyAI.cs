using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace to handle level reloading

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's position
    public float speed = 2f; // Speed of the enemy
    public float separationDistance = 1f; // Minimum distance between enemies
    private int frame = 0;
    private bool isPaused = false;
    public int pauseDuration = 120;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        frame = 0;
    }

    void FixedUpdate()
    {
        if (frame >= pauseDuration)
        {
            frame = 0;
            isPaused = false;
        }
        frame++;
        if (isPaused)
        {
            // Do nothing! WAIT
        }
        else
        {
            Vector2 direction = (player.position - transform.position).normalized;

            // Apply separation behavior
            Vector2 separation = Vector2.zero;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, separationDistance);
            foreach (Collider2D collider in colliders)
            {
                if (collider != GetComponent<Collider2D>() && collider.CompareTag("Enemy"))
                {
                    Vector2 difference = transform.position - collider.transform.position;
                    separation += difference.normalized / difference.magnitude;
                }
            }

            Vector2 moveDirection = direction + separation;
            rb.velocity = moveDirection.normalized * speed;

            // Chance to pause and wait:
            if (Random.Range(0, 2 * 60) == frame) // happen every 2 seconds on avg (2 * 60 frames)
            {
                isPaused = true;
                frame = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player caught!");
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
