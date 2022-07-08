using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : EntityEngine, IPurchased
{
    public int Priсe => 25;
    public string Name => nameof(Tower);
    public string Description => "Атакует всех, рядом находящихся.";

    public List<string> Specifications => new List<string> { "0", "1", "1" };
    [SerializeField] private bool isMainTower;
    public static Tower Instance { get; private set; }
    public override void Awake()
    {
        base.Awake();
        if (isMainTower)
            Instance = this;
    }
    public override void Dead()
    {
        Debug.Log("laterr");
        ///Menu.GetGameOver();
    }
}
