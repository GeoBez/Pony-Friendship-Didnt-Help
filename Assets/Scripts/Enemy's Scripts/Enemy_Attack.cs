using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public GameObject What_Attack;
    public bool isTowerEnemy;
    public float damage;
    public float time;
    float default_Time;
    string Main_Tower;

    void Start()
    {
        time = GetComponentInParent<Enemy>().attackTime;
        damage = GetComponentInParent<Enemy>().damage;
        default_Time = time;
        Main_Tower = "Main Tower";
    }

    void Update()
    {
        if (What_Attack != null)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else if (time < 0)
            {
                if (What_Attack.tag == "MainPlayer")
                    What_Attack.GetComponent<Player>()?.TakeDamage(damage);
                else if (What_Attack.tag == Main_Tower)
                    What_Attack.GetComponent<Tower>()?.TakeDamage(damage);
                time = default_Time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainPlayer" && !isTowerEnemy)
        {
            SetTargetObject(collision.gameObject);
        }
        else if ((collision.tag == Main_Tower) && isTowerEnemy)
        {
            SetTargetObject(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainPlayer" && !isTowerEnemy)
        {
            What_Attack = null;
        }
        else if ((collision.tag == Main_Tower) && isTowerEnemy)
        {
            What_Attack = null;
        }
    }

    private void SetTargetObject(GameObject Target)
    {
        What_Attack = Target;
    }
}
