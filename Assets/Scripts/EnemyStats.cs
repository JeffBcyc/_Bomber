
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    
    private int _maxHealth;
    private int _currentHealth;
    private string _enemyPhrase;
    private CharacterStats _enemyStats;
    
    private void Start()
    {
        _enemyStats = GetComponent<CharacterStats>();
        _enemyPhrase = "this is your nightmare";
        
    }

    public override void OnDeath()
    {
        base.OnDeath();
        Debug.Log(_enemyPhrase);
    }
}
