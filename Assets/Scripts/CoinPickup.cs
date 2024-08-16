using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Transform coinSpawnpoints;
    private int score;
    private int lastCoinSpawnpointIndex;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lastCoinSpawnpointIndex = 0;
        spawnCoin();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = " Score: " + score;
    }

    void spawnCoin()
    {
        if (coinSpawnpoints != null && coinSpawnpoints.transform.childCount > 0)
        {
            // Get the number of children
            int childCount = coinSpawnpoints.transform.childCount;

            // Generate a random index between 0 and childCount-1
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, childCount);
            }
            while (randomIndex == lastCoinSpawnpointIndex);
            lastCoinSpawnpointIndex = randomIndex;

            // Access the randomly selected child
            Transform spawnpoint = coinSpawnpoints.transform.GetChild(randomIndex);
            transform.position = spawnpoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score++;
            spawnCoin();
        }
    }
}
