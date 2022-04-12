using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth = 10;
    public float health;
    public float speed;
    public float damage;
    public bool inTowerCollider = false;

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
        GetComponent<PlayerMovement>().speed = speed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
}
