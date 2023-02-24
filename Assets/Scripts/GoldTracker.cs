using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldTracker : MonoBehaviour
{
    private int gold;
    [SerializeField] private TMP_Text goldLabel;

    private void OnEnable()
    {
        Actions.OnEnemyKilled += updateScore;
    }
    void Start()
    {
        gold = 0;
        goldLabel.text = gold.ToString();
    }

    public void updateScore(Enemy enemy)
    {
        gold += enemy.enemyGoldValue;
        goldLabel.text = gold.ToString();
    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= updateScore;
    }
}
