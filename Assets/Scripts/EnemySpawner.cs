using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn
    public Transform player;  // Reference to the player's position
    public int enemyCount = 8;  // Number of enemies to spawn
    public float spawnRadius = 50f;  // Radius within which enemies will be spawned

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Generate a random position within the spawn radius
            Vector2 spawnPosition = player.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            // Instantiate the enemy prefab at the generated position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            // Set the player's transform to the enemy's script
            enemy.GetComponent<EnemyAI>().player = player;
        }
    }
}

