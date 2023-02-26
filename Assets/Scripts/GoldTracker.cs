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
        Actions.OnEnemyKilled += updateGold;
    }
    void Start()
    {
        gold = 50;
        goldLabel.text = gold.ToString();
    }

    public void updateGold(Enemy enemy)
    {
        gold += enemy.enemyGoldValue;
        goldLabel.text = gold.ToString();
    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= updateGold;
    }

    public int GetGold()
    {
        return gold;
    }

    public void UseGold(int goldUsed)
    {
        gold -= goldUsed;
        goldLabel.text = gold.ToString();
    }
}
