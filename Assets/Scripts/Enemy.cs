using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected int enemyLife = 1;
    public int enemyScoreValue = 1;
    public int enemyGoldValue = 1;
    public int attackValue = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyLife <= 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Actions.OnEnemyKilled?.Invoke(this);
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        enemyLife -= damage;
    }

    public void ReachedGate()
    {
        Actions.OnReachedGate?.Invoke(this);
        Destroy(gameObject);
    }
}
