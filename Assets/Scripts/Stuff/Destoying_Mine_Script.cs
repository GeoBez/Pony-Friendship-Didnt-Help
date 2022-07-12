using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoying_Mine_Script : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Tower_Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeHit(collision.GetComponent<Player>().Health);
        }
    }
}