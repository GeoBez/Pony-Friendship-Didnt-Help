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
	public GameObject[] fall_Object;
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
			Instantiate(fall_Object[0], gameObject.transform.position, Quaternion.identity);
		}

		//потом попытаюсь переделать, ибо с разных мобов могут падать разные плюшки
		if (rnd < 30)
		{
			Instantiate(fall_Object[1], gameObject.transform.position, Quaternion.identity);
		}

		if (rnd < 70)
		{
			if (gameObject.tag == "Enemy")
			{
				fall_Object[2].GetComponent<XP_Ball_Script>().xp_points = 3;
			}
			else if (gameObject.tag == "Tower_Enemy")
			{
				fall_Object[2].GetComponent<XP_Ball_Script>().xp_points = 2;
			}
			Instantiate(fall_Object[2], gameObject.transform.position, Quaternion.identity);
		}

		Wave_System RWN = GameObject.FindGameObjectWithTag("Wave System").GetComponent<Wave_System>();
		RWN.Rise_Wave_Number();
		Destroy(gameObject);
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		healthBar?.SetValue(health);
	}
}
