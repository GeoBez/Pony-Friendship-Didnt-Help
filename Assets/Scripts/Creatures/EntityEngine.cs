using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityEngine : MonoBehaviour
{
    [SerializeField]
    protected float speed = 11;
    public float Speed
    {
        get => speed;
        set
        {
            if (speed >= 0)
                speed = value;
        }
    }

    [SerializeField] protected StatsBar healthBar;
    [SerializeField] private float MaxHealth;
    public float maxHealth
    {
        get => MaxHealth; protected set

        {
            MaxHealth = value;
            healthBar.SetMaxValue(MaxHealth);
        }

    }
    [SerializeField] protected float health;

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


    public static Action<TypeTeam> SomeoneDead;

    public TypeTeam typeTeam { get; protected set; }
    public enum TypeTeam
    {
        Enemy,
        Friend
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

    /// <summary>
    /// Heal to max HP
    /// </summary>
    public void Heal()
    {
        Health += maxHealth;
    }
    public void Heal(float value)
    {
        Health += value;
    }
    public void AddHealsMax(float value)
    {
        maxHealth += value;
        Health += value;
    }
    public void ChangeDamage(float value)
    {
        Damage = value;
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
