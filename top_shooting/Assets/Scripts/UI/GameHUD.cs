using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : Singleton<GameHUD>
{
    private int score;
    private Text scoreText;

    protected override void Awake()
    {
        base.Awake();
        score = 0;

        foreach (var child in transform.GetComponentsInChildren<Transform>(true))
        {
            if (child.name == "ScoreText")
            {
                scoreText = child.GetComponent<Text>();
                break;
            }
        }
    }

    public void AddScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = $"Score: {score}";
    }
}