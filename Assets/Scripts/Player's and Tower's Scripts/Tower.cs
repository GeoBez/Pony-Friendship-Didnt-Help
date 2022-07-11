using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    StatsBar healthBar;
    private float maxHealth = 80;
    public float MaxHealth { get => maxHealth; set {
            if (value > 0)
            {
                maxHealth = value;
                healthBar.SetMaxValue(MaxHealth);
            }
        }
    }
    
    public float health;
    public float damage;
    public int price;

    void Start()
    {
        healthBar = GetComponentInChildren<StatsBar>();
        healthBar.SetMaxValue(MaxHealth);
        health = MaxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetValue(health);
    }
}
