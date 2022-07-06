using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Ball : MonoBehaviour
{
    public int add_Health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MainPlayer")
        {
            Player.MainPlayer.Heal(add_Health);
            Destroy(gameObject);
        }
    }
}
