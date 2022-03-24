using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float health;

    void Update()
    {
		if (health <= 0)
		{
			Death();
		}
	}

    public void Death()
	{
		Destroy(gameObject);
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
	}
}
