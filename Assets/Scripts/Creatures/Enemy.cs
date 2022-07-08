using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : EntityEngine, IFreezable
{
	public int xp_points;
	public float attackTime;
	public GameObject[] fall_Object;

	private static ILoot[] lootsForDefault_Global = new ILoot[] { new Coin(), new Coin(), new HealBall(), new Experience(), new Experience(), new Experience() };
	private ILoot[] lootsForDefault_local;

	public float time;
	public enum TypeEnemy
	{
		Default, Tower, Boss
	}
	[SerializeField]
	private TypeEnemy _TypeEnemy;
	public TypeEnemy EnemyType => _TypeEnemy;
	[SerializeField]
	private Animator _animator;

	public bool FreezeAttac;
	private float SpeedReset;
	public static List<GameObject> Enemys = new List<GameObject>();

	private void Start()
	{
		_animator = GetComponent<Animator>();
		typeTeam = TypeTeam.Enemy;
		lootsForDefault_local = lootsForDefault_Global;
		for (int i = 0; i < lootsForDefault_local.Length; i++)
			if (lootsForDefault_local[i] is Experience)
				lootsForDefault_local[i] = new Experience(xp_points);
		Damage = EnemyType == TypeEnemy.Tower ? 4F : 2F;
		time = 0;
		SpeedReset = Speed;
	}
	public static void AddEnemy(GameObject enemy, Transform transform)
	{
		enemy = Instantiate(enemy, transform.position, transform.rotation);
		Enemys.Add(enemy);
	}
	public override void Dead()
	{
		Enemys.Remove(gameObject);
		int rnd = Random.Range(0, lootsForDefault_Global.Length - 1);
		if (this._TypeEnemy == TypeEnemy.Default || this._TypeEnemy == TypeEnemy.Tower)
		{
			Debug.Log("Generated: " + lootsForDefault_Global[rnd].ToString());
			LootEngine.AddLoot(lootsForDefault_Global[rnd], transform.position);
		}
		else if (this._TypeEnemy == TypeEnemy.Boss)
		{
			LootEngine.AddLoot(new Experience(50), transform.position);
		}
	}
	public static void UpgradeLoot(IModiferUpgrade func)
	{
		ILoot[] loots = func.Expansion(lootsForDefault_Global) as ILoot[];
		if (loots != null) lootsForDefault_Global = loots;
	}

	public void FreezingAnimationStart()
	{
		_animator.SetTrigger("Freezing");
		_animator.SetBool("isWalking", false);
	}

	public void FreezingStart(Ice ice)
	{
		Freezing(true);
		Instantiate(ice, transform.position, Quaternion.identity, transform);
	}
	public void Freezing(bool value)
	{
		FreezeAttac = value;
		var a = GetComponent<Pursuit>();
		if (a != null) a.enabled = !value;

		var ñ = GetComponent<FollowPath>();
		if (ñ != null) ñ.enabled = !value;
	}
	public void FreezingEnd(ParticleSystem iceDestroyParticle)
	{
		Freezing(false);
		Instantiate(iceDestroyParticle, transform.position, Quaternion.identity, transform);
		_animator.SetTrigger("FreezingEnd");
	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (FreezeAttac) return;

		EntityEngine entity = collision.gameObject.GetComponentInParent<EntityEngine>();
		if (time >= 0)
		{
			time -= Time.deltaTime;
			if (EnemyType == TypeEnemy.Tower)
				Speed = 0;
		}
		else if (entity && (entity.typeTeam == TypeTeam.Friend))
		{
			if (EnemyType == TypeEnemy.Tower && entity is Tower || EnemyType != TypeEnemy.Tower)
			{
				entity.TakeHit(Damage);
				time = attackTime;
			}
			if (EnemyType == TypeEnemy.Tower)
				Speed = 0;
		}
		else if (EnemyType == TypeEnemy.Tower)
		{
			Speed = SpeedReset;
		}
	}
}