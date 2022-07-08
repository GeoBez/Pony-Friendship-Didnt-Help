using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EntityEngine : MonoBehaviour
{
    [SerializeField]
    private float speed = 11;
    public float Speed
    {
        get => speed;
        set
        {
            if(speed>=0)
            speed = value;
        }
    }

    public static Action<TypeTeam> SomeoneDead;

    public TypeTeam typeTeam { get; protected set; }
    public enum TypeTeam
    {
        Enemy,
        Friend
    }
    [SerializeField]
    protected StatsBar healthBar;
    [SerializeField]
    private float MaxHealth;
    public float maxHealth { get => MaxHealth; protected set

        {
            MaxHealth = value;
            healthBar.SetMaxValue(MaxHealth);
        }

    }
    [SerializeField]
    protected float health;

    public Rigidbody2D Rigidbody2D { get; protected set; }
    public float Damage { get; protected set; }
    public float Health
    {
        get => health;
        protected set
        {
            if (value > maxHealth)
            {
                value = maxHealth;
            }
            health = value;
            healthBar.SetValue(value);
        }
    }
    public virtual void Awake()
    {
        healthBar = gameObject.GetComponentInChildren<StatsBar>();
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if (maxHealth == 0)
        {
            maxHealth = 10;
            Health = maxHealth;
        }
        Damage = 1F;
        typeTeam = TypeTeam.Friend;
    }
    public abstract void Dead();
    public void Medicament()
    {
        Health += maxHealth;
    }
    public void Medicament(float value)
    {
        Health += value;
    }
    public void AddDamage(float value)
    {
        Damage = value;
    }
    public void AddHealsMax(float value)
    {
        maxHealth += value;
        Health += value;
    }
    public virtual void TakeHit(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Dead();
            Destroy(gameObject);
            SomeoneDead?.Invoke(typeTeam);
        }
    }
    
}
