using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || (collision.tag == "Tower_Enemy" && GetComponentInParent<Player>().mode_YouShallNotPass))
        {
            collision.GetComponent<Enemy>().TakeHit(GetComponentInParent<Player>().damage);
        }
    }
}
