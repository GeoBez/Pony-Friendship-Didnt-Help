using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Script : MonoBehaviour
{
    public int increase_Speed;
    public float damage;
    public float time;
    float default_Time;

    float defaultAttackTime;

    Enemy enemy;
    Boss_Script boss;
    Transform Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponentInParent<Enemy>();
        boss = GetComponentInParent<Boss_Script>();
        defaultAttackTime = enemy.attackTime;
        default_Time = time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.GetComponent<Player>().TakeDamage(damage);
            End_Attack();
        }
    }

    public void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GetComponentInParent<Enemy>().speed += increase_Speed;
            time = default_Time;
        }

        if (Vector3.Distance(transform.position, boss.Target.position) < 1.5)
            End_Attack();
    }

    void End_Attack()
    {
        enemy.speed -= increase_Speed;
        enemy.attackTime = defaultAttackTime;
        boss.RandomAttacks();
        boss.isAttacking = false;
        gameObject.SetActive(false);
    }
}
