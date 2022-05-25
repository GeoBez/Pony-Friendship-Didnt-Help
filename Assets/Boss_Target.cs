using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Target : MonoBehaviour
{
    Transform Player;
    Boss_Script boss;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss_Script>();
    }

    void Update()
    {
        if(boss != null && !boss.isAttacking)
            transform.position = Player.position;
    }
}