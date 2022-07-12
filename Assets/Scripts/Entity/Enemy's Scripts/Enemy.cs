using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity , IFreezable
{

	public int xp_points;

	float defaultSpeed;

	public float attackTime;

	public GameObject[] fall_Object;

	private Animator _animator;

	protected override void OnAwake()
    {
		_animator = GetComponent<Animator>();

		defaultSpeed = Speed;
	}

	void Update()
	{
		if (Speed != defaultSpeed)
		{
			GetComponent<Return_Speed_Script>().speed = Speed;
		}
	}

	public override void Death()
	{
		Statistic.enemyDeathCount++;
		float rnd = Random.Range(0, 99);

		WaveController.NeedToKill--;

		if (gameObject.tag == "Enemy" || gameObject.tag == "Tower Enemy")
		{
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
				fall_Object[2].GetComponent<XP_Ball_Script>().xp_points = xp_points;
				Instantiate(fall_Object[2], gameObject.transform.position, Quaternion.identity);
			}
		}
		else if(gameObject.tag == "Boss")
        {
			fall_Object[0].GetComponent<XP_Ball_Script>().xp_points = xp_points;
			Instantiate(fall_Object[0], gameObject.transform.position, Quaternion.identity);
		}

		//var RWN = GameObject.FindGameObjectWithTag("Wave Controller").GetComponent<WaveController>();
		//RWN.number_Of_Existed_Enemies[RWN.Wave_Number]--;
		//RWN.Rise_Wave_Number();

	}

	public void FreezingAnimationStart()
    {
		TakeHit(1);
		_animator.SetTrigger("Freezing");
		_animator.SetBool("isWalking", false);
	}

	public void FreezingStart(Ice ice)
    {
		var a = GetComponent<Pursuit>();
		if (a != null) a.enabled = false;

		var b = GetComponentInChildren<Enemy_Attack>();
		if (b != null) b.enabled = false;

		var с = GetComponentInChildren<FollowPath>();
		if (с != null) с.enabled = false;

		var d = GetComponent<Boss_Script>();
		if (d != null) d.enabled = false;

		Instantiate(ice, transform.position, Quaternion.identity, transform);
    }

    public void FreezingEnd(ParticleSystem iceDestroyParticle)
    {
		var a = GetComponent<Pursuit>();
		if (a != null) a.enabled = true;

        var b = GetComponentInChildren<Enemy_Attack>();
		if (b != null) b.enabled = true;

		var с = GetComponentInChildren<FollowPath>();
		if (с != null) с.enabled = true;

		var d = GetComponent<Boss_Script>();
		if (d != null) d.enabled = true;

		Instantiate(iceDestroyParticle, transform.position, Quaternion.identity, transform);
		_animator.SetTrigger("FreezingEnd");
	}
}