using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	StatsBar healthBar;
	public float maxHealth = 10;
    public float health;
	public float speed;
	public float damage;
	float defaultSpeed;
	public float attackTime;
	public GameObject Heal_Ball;
	public Set_Victory_Menu all_Enemies;

	private void Start()
	{
		all_Enemies = GameObject.FindGameObjectWithTag("Game Instance").GetComponent<Set_Victory_Menu>();

		healthBar = GetComponentInChildren<StatsBar>();
		healthBar?.SetMaxValue(maxHealth);
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
		all_Enemies.all_Enemies--;
		float rnd = Random.Range(0, 99);
		if (rnd < 5)
		{
			Instantiate(Heal_Ball, gameObject.transform.position, Quaternion.identity);
		}
		Destroy(gameObject);
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		healthBar?.SetValue(health);
	}
}
