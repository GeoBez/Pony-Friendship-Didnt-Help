using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeedLinkedUlt : UltLinkedUpgrades
{
    [Range(1F, 2F)]public float increaseSpeedPower;
    new void Start(){
        base.Start();
    }
    new void Update()
    {
        base.Update();
        if (isUpgradeEnd)
        {
            player.Speed /= increaseSpeedPower;
            isUpgradeEnd = false;
        }
    }
    public override bool TryUse(){
        if(!base.TryUse()) return false;


        player.Speed *= increaseSpeedPower;
        return true;
    }
}
