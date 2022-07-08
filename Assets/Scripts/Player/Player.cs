using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Player : EntityEngine
{
    public static Player MainPlayer;

    public int coinDenomination = 1;
    public float damage;
    public bool inTowerCollider = false;    
    public bool mode_YouShallNotPass = false;

    public bool isMeleeAttacker;
    bool isImmortality;
    float immortality_Timer = .5f;
    float default_Immortality_Timer;

    Change_Attack change_Attack;

    private float RadiusMagnit;
    private float PowerMagnit;

    public void MagtetUpdate(bool poewr = false)
    {
        if (!poewr && RadiusMagnit == 5F)
            RadiusMagnit += 4F;
        else if (poewr && PowerMagnit == 1.5F)
            PowerMagnit = 3F;
    }

    private void Start()
    {
        RadiusMagnit = 5F;
        PowerMagnit = 1.5F;

        PlayerStatistic.ResetAll();
    }  

    public override void Awake()
    {
        base.Awake();

        MainPlayer = this;
        GetComponentInChildren<Weapon>().projectile.coolDown = 0.7F;
        
        change_Attack = GetComponentInChildren<Change_Attack>();
        healthBar.SetMaxValue(maxHealth);
        Health = maxHealth;
        GetComponent<PlayerMovement>().speed = Speed;
              
        //isMeleeAttacker = true;
        if (isMeleeAttacker)
            change_Attack.ChangeAttack();

        //gameObject.AddComponent<Mode_YouShallNoPass>().Activate();
        default_Immortality_Timer = immortality_Timer;


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

    private void Update()
    {
        if(isImmortality)
        {
            immortality_Timer -= Time.deltaTime;
            if(immortality_Timer <= 0)
            {
                isImmortality = false;
                immortality_Timer = default_Immortality_Timer;
            }    
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isImmortality)
        {
            Health -= damage;
            isImmortality = true;
        }
        //healthBar.SetHealth(Health);
    }

    private void LootActivate(GameObject _loot)
    {
        LootEngine loot = _loot.GetComponent<LootEngine>();
        if (!loot)
            return;
        if (loot.Loot == null)
            return;
        loot.Loot.Action();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LootActivate(collision.gameObject);
    }

    public void FixedUpdate()
    {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, RadiusMagnit, LayerMask.GetMask("Item"));
        
        foreach (Collider2D collider in collider2D)
        {
            var loot = collider.gameObject.GetComponent<LootEngine>();
            
            if (loot == null || loot.Rigidbody == null || loot.isStatic)//|| (loot.Loot is not Coin))
            {
                continue;
            }

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

    public override void Dead()
    {
        Menu.GetGameOver();
    }

    public Weapon Weapon { get; private set; }
    public PlayerMeleeAttacks PlayerMelee { get; private set; }
    public PlayerMovement playerMovement { get; private set; }
}
