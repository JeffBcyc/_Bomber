using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    [SerializeField] private int defaultHealth = 100;

    public int MaxHealth { get ; private set; }
    public int CurrentHealth { get; private set; }


    private void Awake()
    {
        MaxHealth = defaultHealth;
        CurrentHealth = MaxHealth;
    }

    public virtual void OnTakeDamage()
    {
        Debug.Log("Player is taking damage");   
        
    }

    public virtual void OnDeath()
    {
        Debug.Log("Object is death");
    }
    
}

