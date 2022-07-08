using UnityEngine;
using System;

public interface ILoot
{
    public object Clone();
    public LootEngine LootEngine { get; set; }
    public string Name { get; }
    public void Action();
}

