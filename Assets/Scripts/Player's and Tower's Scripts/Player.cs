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
    public float speed;
    public float damage;
    public bool inTowerCollider = false;
    public bool mode_YouShallNotPass;
    public bool mode_Magnit=false;
    public bool mode_Double_Denomination = false;
    public bool isMeleeAttacker;
        

    private void Start()
    {
        healthBar.SetMaxValue(maxHealth);
        Health = maxHealth;
        GetComponent<PlayerMovement>().speed = speed;
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
