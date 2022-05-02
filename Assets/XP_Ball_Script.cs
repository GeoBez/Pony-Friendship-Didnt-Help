using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Ball_Script : MonoBehaviour
{
    public int xp_points;
    Finances finances;

    private void Start()
    {
        finances = GameObject.FindGameObjectWithTag("Game Instance").GetComponent<Finances>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.tag == "Player")
        {
            finances.XP += xp_points;
            Destroy(gameObject);
        }
    }
}
