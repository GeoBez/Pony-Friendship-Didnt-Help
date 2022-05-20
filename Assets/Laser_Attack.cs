using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Attack : MonoBehaviour
{
    public int damage;
    public float time;
    float default_Time;
    float defaultAttackTime;
    Enemy enemy;
    Boss_Script boss;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        boss = GetComponentInParent<Boss_Script>();
        defaultAttackTime = enemy.attackTime;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            boss.RandomAttacks();
            boss.isAttacking = false;
            enemy.attackTime = defaultAttackTime;
            time = default_Time;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
