using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    StatsBar healthBar;
    public float maxHealth = 80;
    public float health;
    public float damage;
    public int price;

    void Start()
    {
        healthBar = GetComponentInChildren<StatsBar>();
        healthBar.SetMaxValue(maxHealth);
        health = maxHealth;
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
