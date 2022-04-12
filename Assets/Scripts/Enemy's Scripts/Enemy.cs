using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public HealthBar healthBar;
	public float maxHealth = 10;
    public float health;
	public float speed;
	public float damage;
	public float defaultSpeed;
	public float attackTime;

	private void Start()
	{
		healthBar?.SetMaxHealth(maxHealth);
        health = maxHealth;

		defaultSpeed = speed;
	}

	void Update()
	{
		if (health <= 0)
		{
			Death();
		}

		if (speed != defaultSpeed)
		{
			GetComponent<Return_Speed_Script>().speed = speed;
		}
	}

	public void Death()
	{
		Destroy(gameObject);
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		healthBar?.SetHealth(health);
	}
}
