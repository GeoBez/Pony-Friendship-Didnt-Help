using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBall : Loot, ILoot
{
    public string Name => nameof(HealBall);
    public override void Action()
    {
        Player.MainPlayer.Heal(5);
        base.Action();
    }
}
