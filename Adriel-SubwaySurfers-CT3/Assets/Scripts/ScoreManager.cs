using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score;
    TMP_Text textScore;

    void Start()
    {
        score = 0;
        textScore = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        textScore.text = "Score: " + score.ToString();
    }

    public void addScore(int points)
    {
        score += points;
    }
}
