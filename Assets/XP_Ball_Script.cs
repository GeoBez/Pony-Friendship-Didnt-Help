using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Ball_Script : MonoBehaviour
{
    public int xp_points;
    GameObject XP_Bar_Object;

    private void Start()
    {
        XP_Bar_Object = GameObject.FindGameObjectWithTag("XP Bar");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.tag == "Player")
        {
            XP_Bar_Object.GetComponent<XP_Bar>().Update_Bar(xp_points);
            Finances.XP += xp_points;
            Destroy(gameObject);
        }
    }
}
