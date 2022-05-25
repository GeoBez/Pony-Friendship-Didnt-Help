using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public StatsBar healthBar;
    public float maxHealth = 10;
    private float health;
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
    public float damage;

    public bool inTowerCollider = false;

    public bool mode_YouShallNotPass;

    public bool mode_Magnit = false;
    public bool mode_Double_Denomination = false;
    public bool mode_Clover_Leaf = false;
    public bool mode_MoreBits = false;
    public bool mode_Sturdy = false;
    public bool mode_HealthyHealth = false;
    public bool mode_NewHorseshoes = false;
    public bool mode_OneTimeTreatment = false;
    public bool mode_MoreHealth = false;
    public bool mode_TimeIsMoney = false;
    public bool mode_IAmPower = false;
    public bool mode_PowerPlus = false;

    public bool isMeleeAttacker;

    Change_Attack change_Attack;

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

        //gameObject.AddComponent<Mode_YouShallNoPass>().Activate();

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
        //if(Health > maxHealth)
        //{
        //    Health = maxHealth;
        //}
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        //healthBar.SetHealth(Health);
    }
}
