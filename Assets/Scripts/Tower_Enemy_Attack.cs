using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Enemy_Attack : MonoBehaviour
{
    Tower What_Attack;
    public float damage;
    public float time;
    float default_Time;
    bool attacking;

    void Start()
    {
        default_Time = time;
    }

    void Update()
    {
        if(attacking)
        {
            if(time >= 0)
            {
                time -= Time.deltaTime;
            }
            else if (time < 0)
            {
                What_Attack.TakeDamage(damage);
                time = default_Time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tower" || collision.tag == "Main Tower")
        {
            What_Attack = collision.GetComponent<Tower>();
            attacking = true;
        }
    }
}
