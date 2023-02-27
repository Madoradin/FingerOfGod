using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreLabel;
    
    private void OnEnable()
    {
        Actions.OnEnemyKilled += updateScore;
    }
    void Start()
    {
        score = 0;
        scoreLabel.text = "Score: " + score.ToString();
    }

    public void updateScore(Enemy enemy)
    {
        score += enemy.enemyScoreValue;
        scoreLabel.text = "Score: " + score.ToString();
    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= updateScore;
    }
}
