using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace to handle level reloading

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's position
    public float speed = 3f; // Speed of the enemy
    private bool isPaused = false;
    private float elapsedTime = 0f;
    public int pauseDuration = 2;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        elapsedTime = 0;
    }

    void FixedUpdate()
    {
        if (isPaused)
        {
            if (elapsedTime >= pauseDuration)
            {
                elapsedTime = 0;
                isPaused = false;
            }
            elapsedTime += Time.deltaTime;
        }
        else
        {
            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 moveDirection = direction;
            rb.velocity = moveDirection.normalized * speed;

            // Chance to pause and wait:
            if (elapsedTime >= 0.1)
            {
                if (Random.Range(0, 100) == 1)
                {
                    isPaused = true;
                    elapsedTime = 0;
                }
            }
            elapsedTime += Time.deltaTime;
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
