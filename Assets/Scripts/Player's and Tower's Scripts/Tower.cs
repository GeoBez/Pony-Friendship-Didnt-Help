using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth = 80;
    public float health;
    public float damage;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
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
        healthBar.SetHealth(health);
    }
}
