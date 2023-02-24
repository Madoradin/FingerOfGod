using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    [SerializeField] private int castleLife = 100;
    [SerializeField] private TMP_Text healthText;

    private void OnEnable()
    {
        Actions.OnReachedGate += TakeDamage;
    }
    private void OnDisable()
    {
        Actions.OnReachedGate -= TakeDamage;
    }
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = castleLife.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(Enemy enemy)
    {
        castleLife -= enemy.attackValue;
        healthText.text = castleLife.ToString();
    }
}
