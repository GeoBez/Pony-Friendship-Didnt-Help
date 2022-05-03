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
    public bool mode_Magnit = false;
    public bool mode_Double_Denomination = false;
    public bool mode_Clover_Leaf = false;
    public bool mode_MoreBits = false;
    public bool mode_Sturdy = false;
    public bool mode_HealthyHealth = false;
    public bool mode_NewHorseshoes = false;
    public bool mode_OneTimeTreatment = false;
    public bool mode_MoreHealth = false;

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
