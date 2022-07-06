using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : Loot, ILoot
{
    private readonly int Value;
    public Experience(int _Value = 1)
    {
        if (_Value > 0)
            Value = _Value;
        else
            Value = 1;
    }
    public string Name => nameof(Experience);

    public override void Action()
    {
        PlayerStatistic.AddExperience(Value);
        base.Action();
    }
}
