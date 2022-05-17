using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLinckedUlt : UltLinkedUpgrades
{
    [Range(1, 50)]public float healPower;
    new void Start(){
        base.Start();
    }
    new void Update(){
        base.Update();
    }
    public override bool TryUse(){

        if(!base.TryUse()) return false;

        player.Health += healPower;
        return true;

    }
}
