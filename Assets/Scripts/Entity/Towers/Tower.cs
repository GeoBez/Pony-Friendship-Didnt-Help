using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Entity
{
    [SerializeField] private bool IsMainTower;

    public int price;
    protected override void OnAwake()
    {
    }

    public override void Death()
    {
        if (IsMainTower)
            Set_Game_Over.SetActive();
    }
}
