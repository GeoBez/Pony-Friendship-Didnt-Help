using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player MainPlayer;

    public float damage;
    public bool inTowerCollider = false;    
    public bool mode_YouShallNotPass = false;

    public bool isMeleeAttacker;
    bool isImmortality;
    float immortality_Timer = .5f;
    float default_Immortality_Timer;

    Change_Attack change_Attack;

    public StatsBar healthBar;
    public float maxHealth = 10;
    private float health;
    private float RadiusMagnit;
    private float PowerMagnit;

    private void Start()
    {
        RadiusMagnit = 5F;
        PowerMagnit = 1.5F;        
    }
    public float Health
    {
        get => health;
        set  
        {
            if (value <= maxHealth)
            {
                health = value;
                healthBar.SetValue(value);
            }
        }
    }
    
    private float speed = 11;// тут ручками теперь править нужно. Сорямба :)
    public float Speed
    {
        get => speed;
        set
        {
            speed = value;
            GetComponent<PlayerMovement>().speed = value;
        }
    }

    private void Awake()
    {
        GetComponentInChildren<Weapon>().projectile.coolDown = 0.7F;
        
        change_Attack = GetComponentInChildren<Change_Attack>();
        healthBar.SetMaxValue(maxHealth);
        Health = maxHealth;
        GetComponent<PlayerMovement>().speed = Speed;
              
        //isMeleeAttacker = true;
        if (isMeleeAttacker)
            change_Attack.ChangeAttack();

        gameObject.AddComponent<Mode_YouShallNoPass>().Activate();
        default_Immortality_Timer = immortality_Timer;
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

        if (Input.GetKeyDown(KeyCode.Space))
            {
            LootEngine.AddLoot(new Experience(), new Vector3(transform.position.x + 10, transform.position.y,
transform.position.z));
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
}
