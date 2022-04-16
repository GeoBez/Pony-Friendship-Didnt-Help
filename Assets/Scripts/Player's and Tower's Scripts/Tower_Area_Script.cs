using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Area_Script : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            collision.GetComponent<Player>().inTowerCollider = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().inTowerCollider = false;
        }
    }
}
