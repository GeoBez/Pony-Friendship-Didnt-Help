using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public float damage;
    public float time;

    private void Awake()
    {
        transform.eulerAngles = GameObject.FindGameObjectWithTag("Boss").GetComponentInChildren<Spawn_Laser>().angle;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "MainPlayer")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
