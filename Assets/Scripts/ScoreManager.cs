using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = " Score: " + score;
        if (elapsedTime >= 1)
        {
            elapsedTime = 0;
            score++;
        }
        elapsedTime += Time.deltaTime;
    }
}
