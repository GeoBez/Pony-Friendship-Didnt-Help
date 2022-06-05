using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Target : MonoBehaviour
{
    Transform Player;
    public Boss_Script boss;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(boss != null && !boss.isAttacking)
            transform.position = Player.position;
    }
}