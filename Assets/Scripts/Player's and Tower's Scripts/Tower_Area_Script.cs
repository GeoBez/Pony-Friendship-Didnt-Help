using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Area_Script : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            player.GetComponent<Player>().inTowerCollider = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Player>().inTowerCollider = false;
        }
    }
}
