using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Mine_Script : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Player.MainPlayer.Speed /= 2;
        }
    }
}