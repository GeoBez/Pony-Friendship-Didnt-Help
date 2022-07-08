using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Player : EntityEngine
{

    public static Player MainPlayer;
    private float RadiusMagnit;
    private float PowerMagnit;
    public Weapon Weapon { get; private set; }
    public PlayerMeleeAttacks PlayerMelee { get; private set; }
    public PlayerMovement playerMovement { get; private set; }

    public override void Awake()
    {
        base.Awake();
        MainPlayer = this;
        Weapon = GetComponentInChildren<Weapon>();
        PlayerMelee = GetComponentInChildren<PlayerMeleeAttacks>();
        Weapon.projectile.coolDown = 0.7F;
        RadiusMagnit = 5F;
        PowerMagnit = 1.5F;
        AddHealsMax(10F);
        playerMovement = GetComponent<PlayerMovement>();
    } 
    public void MagtetUpdate(bool poewr = false)
    {
        if (!poewr && RadiusMagnit == 5F)
            RadiusMagnit += 4F;
        else if (poewr && PowerMagnit == 1.5F)
            PowerMagnit = 3F;
    }
    public override void Dead()
    {
        Menu.GetGameOver();
    }
    private void LootActivate(GameObject _loot)
    {
        LootEngine loot = _loot.GetComponent<LootEngine>();
        if (!loot) return;
        if(loot.Loot == null) return;
        loot.Loot.Action();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LootActivate(collision.gameObject);
    }
    public void FixedUpdate()
    {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, RadiusMagnit);
        foreach (Collider2D collider in collider2D)
        {
            LootEngine loot = collider.gameObject.GetComponent<LootEngine>();
            if (loot == null || loot.Rigidbody == null || loot.Loot is not Coin) continue;
            Rigidbody2D rb = loot.Rigidbody;
            if (rb)
            {
                float dictanceToPlayer = Vector2.Distance(collider.transform.position, transform.position);
                if (dictanceToPlayer <= RadiusMagnit)
                {
                    rb.velocity = (transform.position - loot.transform.position) * PowerMagnit;
                }
                else rb.velocity = new Vector2(0, 0);
            }
        }
    }

}
