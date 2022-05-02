using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Ball_Script : MonoBehaviour
{
    public int xp_points;

    public void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.tag == "Player")
        {
            Finances.XP += xp_points;
            Destroy(gameObject);
        }
    }
}
