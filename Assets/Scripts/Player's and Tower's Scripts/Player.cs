using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player MainPlayer;

    public StatsBar healthBar;
    [SerializeField]private float maxHealth = 10;
    public float MaxHealth { get => maxHealth; set {
            if (value > 0)
            {
                Health = value - health;
                maxHealth = value;
                healthBar.SetMaxValue(MaxHealth);
            }
        } }
    private float health;
    [SerializeField] private Text atackUi;
    public float Health
    {
        get => health;
        set  
        {
            if (value <= MaxHealth)
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

    public int Damage { get => damage; set {
            if (value > 0)
            {
                damage = value;
                atackUi.GetComponent<AtackPowerText>().UpdateText(damage);
            }

        } }
    [SerializeField]private int damage;

    public bool inTowerCollider = false;

    public static bool mode_YouShallNotPass;
    public static bool mode_YouShallNoPass = false;
    public bool isMeleeAttacker;

    bool isImmortality;

    float immortality_Timer = .5f;
    float default_Immortality_Timer;

    Change_Attack change_Attack;

    private void Awake()
    {
        GetComponentInChildren<Weapon>().projectile.coolDown = 0.7F;
        
        change_Attack = GetComponentInChildren<Change_Attack>();
        healthBar.SetMaxValue(MaxHealth);
        Health = MaxHealth;
        GetComponent<PlayerMovement>().speed = Speed;
              
        //isMeleeAttacker = true;
        if (isMeleeAttacker)
            change_Attack.ChangeAttack();

        gameObject.AddComponent<Mode_YouShallNoPass>().Activate();
        //new Mode_MoreBits().Activate();
        //gameObject.AddComponent<Mode_YouShallNoPass>().Activate();
        default_Immortality_Timer = immortality_Timer;
    }

    void Start()
    {
        //var u = gameObject.AddComponent<Mode_MoreBits>();
        //u.Activate();

        //var u = new Mode_IAmSpeed();
        //u.Activate();
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
}
