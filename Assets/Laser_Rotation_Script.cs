using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Rotation_Script : MonoBehaviour
{
    Transform Player;
    public float time;
    float default_Time;

    float defaultAttackTime;

    Boss_Script boss;
    Enemy Enemy;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GetComponentInParent<Boss_Script>();
        Enemy = GetComponentInParent<Enemy>();
        defaultAttackTime = Enemy.attackTime;
        default_Time = time;
    }

    private void Update()
    {
        transform.position = Player.position;
        //transform.Rotate(0f, 0, 0.5f, Space.Self);

        time -= Time.deltaTime;
        if(time <= 0)
        {
            boss.RandomAttacks();
            boss.isAttacking = false;
            Enemy.attackTime = defaultAttackTime;
            time = default_Time;
            gameObject.SetActive(false);
        }
    }
}
