using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Attack : MonoBehaviour
{
    public int damage;
    public float time;
    public float delay;
    float default_Time;
    float default_Delay;
    float defaultAttackTime;

    Enemy enemy;
    Boss_Script boss;
    Player Player;

    SpriteRenderer sprite;
    BoxCollider2D collider;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        boss = GetComponentInParent<Boss_Script>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        defaultAttackTime = enemy.attackTime;
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        default_Delay = delay;
        default_Time = time;
        sprite.enabled = false;
        collider.enabled = false;
    }

    private void Update()
    {
        if(delay <= 0)
        {
            time -= Time.deltaTime;
            sprite.enabled = true;
            collider.enabled = true;
        }
        else if(delay > 0)
        {
            delay -= Time.deltaTime;
            sprite.enabled = false;
            collider.enabled = false;
        }

        if(time <= 0)
        {
            boss.RandomAttacks();
            boss.isAttacking = false;
            enemy.attackTime = defaultAttackTime;
            time = default_Time;
            delay = default_Delay;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.TakeDamage(damage);
        }
    }
}
