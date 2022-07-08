using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Target : MonoBehaviour
{
    Transform _Player;
    public Boss_Script boss;

    void Start()
    {
        _Player = Player.MainPlayer.transform;
    }

    void Update()
    {
        if(boss != null && !boss.isAttacking)
            transform.position = _Player.position;
    }
}