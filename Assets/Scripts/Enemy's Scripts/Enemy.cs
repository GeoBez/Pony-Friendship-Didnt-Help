using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EntityEngine, IFreezable
{
	private Animator _animator;
	float defaultSpeed;
	private static ILoot[] lootsForDefault_Global = new ILoot[] { new Coin(), new Coin(), new Coin(),
			new HealBall(), new Experience(), new Experience(), new Experience() };
	private ILoot[] lootsForDefault_local;

	public static List<GameObject> Enemys = new List<GameObject>();

	public bool FreezeAttac;
	public float time;
	public float attackTime;
	public float damage;
	public int xp_points;

	private float SpeedReset;

	public enum TypeEnemy
	{
		Default, Tower, Boss
	}

	[SerializeField]
	private TypeEnemy _TypeEnemy;
	public TypeEnemy EnemyType => _TypeEnemy;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		healthBar = GetComponentInChildren<StatsBar>();
		healthBar?.SetMaxValue(maxHealth);
		health = maxHealth;

		defaultSpeed = speed;
				
		typeTeam = TypeTeam.Enemy;
		lootsForDefault_local = lootsForDefault_Global;
		for (int i = 0; i < lootsForDefault_local.Length; i++)
			if (lootsForDefault_local[i] is Experience)
				lootsForDefault_local[i] = new Experience(xp_points);
		Damage = EnemyType == TypeEnemy.Tower ? 4F : 2F;
		time = 0;
		SpeedReset = Speed;		
	}

	/*public static void UpgradeLoot(IModiferUpgrade func)
	{
		ILoot[] loots = func.Expansion(lootsForDefault_Global) as ILoot[];
		if (loots != null) lootsForDefault_Global = loots;
	}*/


	public override void Dead()
	{		
		Statistic.enemyDeathCount++;

		Enemys.Remove(gameObject);
		int rnd = Random.Range(0, lootsForDefault_local.Length - 1);
		if (this._TypeEnemy == TypeEnemy.Default || this._TypeEnemy == TypeEnemy.Tower)
		{
			//if (lootsForDefault_Global)
			LootEngine.AddLoot(lootsForDefault_local[rnd], transform.position);
		}
		else if (this._TypeEnemy == TypeEnemy.Boss)
		{
			LootEngine.AddLoot(new Experience(50), transform.position);
		}
					
		Destroy(gameObject);
		WaveController.NeedToKill--;		
	}

	public void FreezingAnimationStart()
	{
		_animator.SetTrigger("Freezing");
		_animator.SetBool("isWalking", false);
	}

	public void FreezingStart(Ice ice)
	{
		var a = GetComponent<Pursuit>();
		if (a != null) a.enabled = false;

		var b = GetComponentInChildren<Enemy_Attack>();
		if (b != null) b.enabled = false;

		var ñ = GetComponentInChildren<FollowPath>();
		if (ñ != null) ñ.enabled = false;

		Instantiate(ice, transform.position, Quaternion.identity, transform);
	}
	public void FreezingEnd(ParticleSystem iceDestroyParticle)
	{
		var a = GetComponent<Pursuit>();
		if (a != null) a.enabled = true;

		var b = GetComponentInChildren<Enemy_Attack>();
		if (b != null) b.enabled = true;

		var ñ = GetComponentInChildren<FollowPath>();
		if (ñ != null) ñ.enabled = true;

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

	/*StatsBar healthBar;
	public float maxHealth = 10;
    public float health;
	public float speed;
	public float attackTime;
	*/
}