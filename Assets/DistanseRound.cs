using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanseRound : MonoBehaviour
{
    public Weapon weapon;
    public PlayerMeleeAttacks meleeAttacks;

    private void Start()
    {
        transform.localScale = new Vector2(0, 0);
    }
    private void Update()
    {
        if (weapon.enabled && !meleeAttacks.enabled) transform.localScale = new Vector2(weapon.detectionDistance, weapon.detectionDistance);
        if (!weapon.enabled && meleeAttacks.enabled) transform.localScale = new Vector2(meleeAttacks.attackRange, meleeAttacks.attackRange);
    }
}
