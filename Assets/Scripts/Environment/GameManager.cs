using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int scoreGain = 10;
    public float scoreInterval = 5f;

    private float scoreGainTimer = 0f;
    int score = 0;
    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }


    void UpdateScore()
    {
        scoreGainTimer += Time.deltaTime;
        if (scoreGainTimer >= scoreInterval)
        {
            score += scoreGain;
            scoreText.text = "Score: " + score.ToString();
            scoreGainTimer = 0f;
        }

    }
}
