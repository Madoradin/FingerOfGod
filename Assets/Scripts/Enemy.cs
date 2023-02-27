using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected int enemyLife = 1;
    public int enemyScoreValue = 1;
    public int enemyGoldValue = 1;
    public int attackValue = 1;
    [SerializeField] private GameObject deathAnim;



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
        Vector3 bloodspawn = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0.53f, 1000f), transform.position.z);
        Actions.OnEnemyKilled?.Invoke(this);
        Instantiate(deathAnim, bloodspawn, Quaternion.Euler(90, 0, 90));
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
