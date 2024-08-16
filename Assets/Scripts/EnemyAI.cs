using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace to handle level reloading

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's position
    public float speed = 3f; // Speed of the enemy
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
            // LOSE CURRENT PLAYER POSITION
        }
        else
        {
            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 moveDirection = direction;
            rb.velocity = moveDirection.normalized * speed;

            // Chance to pause and wait:
            if (Random.Range(0, 2 * 60) == frame) // happen every 2 seconds on avg (2 * 60 frames)
            {
                isPaused = true;
                frame = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over!");
        RestartLevel();
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
